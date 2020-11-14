using System;
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

    public event Action<int, UpgradeType> upgradeSkill;
    public void UpgradeSkill(int _skillID, UpgradeType _upgrade)
    {
        if (upgradeSkill != null)
        {
            upgradeSkill(_skillID, _upgrade);
        }
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

    public event Action<Vector3> dashToLocation;
    public void DashToLocation(Vector3 _dir)
    {
        if (dashToLocation != null)
        {
            dashToLocation(_dir);
        }
    }
}
