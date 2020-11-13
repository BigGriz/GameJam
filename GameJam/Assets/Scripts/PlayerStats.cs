using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singleton
    public static PlayerStats instance;
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
    }
    #endregion

    public float health, maxHealth;
    public float mana, maxMana;

    private void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    public bool TakeDamage(float _damage)
    {
        health -= _damage;
        UIHandler.instance.UpdateHealth(health / maxHealth);
        return (health <= 0);
    }

    public bool SpendMana(float _mana)
    {
        if (mana - _mana < 0)
            return false;

        mana -= _mana;
        UIHandler.instance.UpdateMana(mana / maxMana);
        return true;
    }
}
