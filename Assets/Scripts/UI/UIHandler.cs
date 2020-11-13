using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    #region Singleton
    public static UIHandler instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one UIHandler exists!");
            Destroy(this.gameObject);
        }
        instance = this;
    }
    #endregion Singleton

    public event Action<float> updateHealth;
    public void UpdateHealth(float _health)
    {
        if (updateHealth != null)
        {
            updateHealth(_health);
        }
    }

    public event Action<float> updateMana;
    public void UpdateMana(float _mana)
    {
        if (updateMana != null)
        {
            updateMana(_mana);
        }
    }
}
