﻿using System;
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

    private void Start()
    {
        uiGatePuzzle = gatePuzzle.GetComponentInChildren<UIGatePuzzle>();
        uiSwitchPuzzle = switchPuzzle.GetComponentInChildren<UISwitchPuzzle>();
        uiRotatePuzzle = rotatePuzzle.GetComponentInChildren<UIRotatePuzzle>();
        deathAnimator = deathScreen.GetComponent<Animator>();
        ToggleGatePuzzle(false);
        ToggleSwitchPuzzle(false);
        ToggleRotatePuzzle(false);
    }

    public GameObject deathScreen;
    Animator deathAnimator;
    public void PlayerDeath()
    {
        deathAnimator.SetTrigger("Death");
        Invoke("ReturnToMainMenu", 3.0f);
    }
    public void ReturnToMainMenu()
    {
        MapController.instance.ReturnToMain();
    }

    public GameObject rotatePuzzle;
    UIRotatePuzzle uiRotatePuzzle;
    public void ToggleRotatePuzzle(bool _toggle)
    {
        if (!uiRotatePuzzle.solved)
            rotatePuzzle.SetActive(_toggle);
    }

    public GameObject gatePuzzle;
    UIGatePuzzle uiGatePuzzle;
    public void ToggleGatePuzzle(bool _toggle)
    {
        if (!uiGatePuzzle.solved)
            gatePuzzle.SetActive(_toggle);
    }

    public GameObject switchPuzzle;
    UISwitchPuzzle uiSwitchPuzzle;
    public void ToggleSwitchPuzzle(bool _toggle)
    {
        if (!uiSwitchPuzzle.solved)
            switchPuzzle.SetActive(_toggle);
    }


    public int numEnemies;
    public void EnemyDeath()
    {
        numEnemies--;
        SetCount(numEnemies);
        if (numEnemies <= 0 && EnemySpawner.instance.type == GameType.Eliminate)
        {
            // You Win
            if (MapController.instance)
            MapController.instance.MapComplete();
        }
    }

    public void AddEnemy()
    {
        numEnemies++;
        SetCount(numEnemies);
    }

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

    public event Action<int> setCount;
    public void SetCount(int _count)
    {
        if (setCount != null)
        {
            setCount(_count);
        }
    }
}
