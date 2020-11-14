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
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        stats = new ProjectileStats();
        stats.damage = damage;
        stats.speed = 10.0f;
    }
    void Start()
    {
        player = PlayerStats.instance;
        health = maxHealth;
        mana = maxMana;

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
    public float maxHealth, maxMana;
    public float attackCooldown;
    public float damage;

    public GameObject projectile;
    ProjectileStats stats;

    // Local Vars
    float attackDistance;
    float cooldown;
    float health, mana;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            if (cooldown <= 0)
            {
                Attack();
            }
            FaceTarget(player.transform.position);
        }
        agent.SetDestination(player.transform.position);
  
        UpdateCooldown(Time.deltaTime);
    }

    public void UpdateCooldown(float _time)
    {
        cooldown -= (cooldown > 0) ? _time : cooldown;
    }

    public void Attack()
    {
        // Play Anim Here

        switch (type)
        {
            case EnemyType.Melee:
            {
                player.TakeDamage(damage);
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

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10.0f);
    }
    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        UIHandler.instance.EnemyDeath();
        Destroy(this.gameObject);
    }
}
