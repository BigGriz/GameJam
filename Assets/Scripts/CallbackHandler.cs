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
}
