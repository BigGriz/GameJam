using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStats : MonoBehaviour
{
    #region Singleton
    public static PlayerStats instance;
    Animator animator;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one PlayerStats exists!");
            Destroy(this.gameObject);
        }
        instance = this;

        health = maxHealth;
        mana = maxMana;
        animator = GetComponentInChildren<Animator>();
    }
    #endregion

    public float health, maxHealth;
    public float mana, maxMana;
    float regenTimer = 0.0f;
    bool dying;
    bool reload;
    float reloadTimer;

    private void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    private void Update()
    {
        regenTimer -= Time.deltaTime;
        animator.SetBool("Dead", dying);
        if (regenTimer <= 0)
            Regen();
        if (reloadTimer > 0 && reload)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                reload = false;
                mana = maxMana;
            }
        }
    }

    public void Regen()
    {
        health += health == maxHealth ? 0 : 1.0f;
        //mana += mana == maxMana ? 0 : 1.0f;
        regenTimer += 1.0f;

        UIHandler.instance.UpdateHealth(health / maxHealth);
        UIHandler.instance.UpdateMana(mana / maxMana);
    }

    public bool TakeDamage(float _damage)
    {
        health -= _damage;
        UIHandler.instance.UpdateHealth(health / maxHealth);
        CallbackHandler.instance.StopPlayer();

        if (health <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<NavMeshAgent>().isStopped = true;
            dying = true;
            this.enabled = false;
        }
        return (health <= 0);
    }

    public bool SpendMana(float _mana)
    {
        if (mana - _mana < 0)
            return false;

        mana -= _mana;
        if (mana <= 0)
        {
            reload = true;
            reloadTimer = 2.0f;
        }

        UIHandler.instance.UpdateMana(mana / maxMana);
        return true;
    }

    public void Shoot()
    {
        animator.ResetTrigger("Shoot");
        animator.SetTrigger("Shoot");
    }
}
