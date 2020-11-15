using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIEnemyCount : MonoBehaviour
{
    #region Setup & Callbacks
    TMPro.TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        UIHandler.instance.setCount += SetCount;
    }
    private void OnDestroy()
    {
        UIHandler.instance.setCount -= SetCount;
    }
    #endregion Setup & Callbacks

    public void SetCount(int _numEnemies)
    {
        text.SetText("Enemies Remaining: " + _numEnemies);
    }
}
