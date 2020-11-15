using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    Melee,
    Ranged
}

public class Enemy : MonoBehaviour
{
    #region Setup
    NavMeshAgent agent;
    PlayerStats player;
    Animator animator;
    float speed;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = new ProjectileStats();
        stats.damage = damage;
        stats.speed = 10.0f;
        animator = GetComponentInChildren<Animator>();
        speed = agent.speed;
        GetComponentInChildren<Hitbox>().damage = damage;
    }
    void Start()
    {
        health = maxHealth;

        switch (type)
        {
            case EnemyType.Melee:
            {
                attackDistance = 2.0f;
                break;
            }
            case EnemyType.Ranged:
            {
                attackDistance = 10.0f;
                    
                break;
            }
        }

        agent.stoppingDistance = attackDistance;
        Invoke("UpdateCount", 0.02f);
    }

    void UpdateCount()
    {
        UIHandler.instance.AddEnemy();
    }

    #endregion Setup

    [Header("Setup Fields")]
    public EnemyType type;
    public float maxHealth;
    public float attackCooldown;
    public float damage;

    public GameObject projectile;
    ProjectileStats stats;

    // Local Vars
    float attackDistance;
    float cooldown;
    float health;
    bool dying;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Dead", dying);
        if (dying)
            return;

        if (!player || !player.enabled)
        { 
            animator.SetFloat("Movement", 0.0f);
            return;
        }
        
        // Need Aggro Range Here.
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            if (cooldown <= 0)
            {
                Attack();
            }
            FaceTarget(player.transform.position);
        }

        animator.SetFloat("Movement", agent.velocity.magnitude / agent.speed);
        agent.SetDestination(player.transform.position);
  
        UpdateCooldown(Time.deltaTime);
        agent.speed = Mathf.Lerp(agent.speed, speed, Time.deltaTime * 4);
    }

    public void UpdateCooldown(float _time)
    {
        cooldown -= (cooldown > 0) ? _time : cooldown;
    }

    public void Attack()
    {
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Attack");
        StopEnemy();

        switch (type)
        {
            case EnemyType.Melee:
            {
                cooldown = attackCooldown;
                break;
            }
            case EnemyType.Ranged:
            {
                Projectile temp = Instantiate(projectile, this.transform.position + this.transform.forward, Quaternion.identity).GetComponent<Projectile>();
                Physics.IgnoreCollision(temp.GetComponent<Collider>(), this.GetComponent<Collider>());
                temp.transform.rotation = Quaternion.Euler(0.0f, this.transform.rotation.eulerAngles.y, 0.0f);
                temp.projStats = stats;

                cooldown = attackCooldown;
                break;
            }
        }
    }

    public void StopEnemy()
    {
        if (agent && agent.enabled)
        {
            agent.ResetPath();
            agent.speed = 0;
        }
    }

    public void IncreaseAggro()
    {
        GetComponent<SphereCollider>().radius *= 2;
    }


    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10.0f);
    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
        StopEnemy();
        if (health <= 0 && !dying)
        {
            dying = true;
            Die();
        }
    }

    public void Die()
    {
        animator.ResetTrigger("Attack");
        animator.SetTrigger("Death");
        agent.isStopped = true;
        agent.enabled = false;

        UIHandler.instance.EnemyDeath();
        int rand = Random.Range(0, 10);
        if (rand == 1)
        {
            CallbackHandler.instance.CreateCash(transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats temp = other.GetComponentInParent<PlayerStats>();
        if (temp)
        {
            player = temp;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerStats>())
        {
            player = null;
        }
    }
}
