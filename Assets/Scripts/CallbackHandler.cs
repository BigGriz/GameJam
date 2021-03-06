﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackHandler : MonoBehaviour
{
    public static CallbackHandler instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Callback Handler exists!");
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Start()
    {
        Invoke("UpdateMoney", 0.1f);
    }

    public GameObject cashCollectable;
    int money;
    public void AddMoney(int _money)
    {
        money += _money;
        UpdateMoney();
    }
    public void SpendMoney(int _money)
    {
        money -= _money;
        UpdateMoney();
    }
    public bool CheckMoney(int _money)
    {
        return (money >= _money);
    }
    public event Action<int> updateMoney;
    public void UpdateMoney()
    {
        if (updateMoney != null)
        {
            updateMoney(money);
        }
    }

    public void CreateCash(Vector3 _position)
    {
        Instantiate(cashCollectable, _position, Quaternion.identity);
    }


    public event Action<int, UpgradeType> upgradeSkill;
    public void UpgradeSkill(int _skillID, UpgradeType _upgrade)
    {
        if (upgradeSkill != null)
        {
            upgradeSkill(_skillID, _upgrade);
        }
    }

    // temp
    public Skill pistol;
    public void Upgrade(UpgradeType _type)
    {
        pistol.UpgradeSkill(_type);
    }

    public event Action stopPlayer;
    public void StopPlayer()
    {
        if (stopPlayer != null)
        {
            stopPlayer();
        }
    }

    public event Action<int> disableLayer;
    public void DisableLayer(int _layer)
    {
        if (disableLayer != null)
        {
            disableLayer(_layer);
        }
    }

    public event Action killProjectiles;
    public void KillProjectiles()
    {
        if (killProjectiles != null)
        {
            killProjectiles();
        }
    }

    public event Action killEnemies;
    public void KillEnemies()
    {
        if (killEnemies != null)
        {
            killEnemies();
        }
    }

    public event Action<Vector3> dashToLocation;
    public void DashToLocation(Vector3 _dir)
    {
        if (dashToLocation != null)
        {
            dashToLocation(_dir);
        }
    }
}
