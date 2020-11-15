using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    #region Setup
    TMPro.TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    #endregion Setup
    #region Callbacks
    void Start()
    {
        CallbackHandler.instance.updateMoney += UpdateMoney;
    }
    private void OnDestroy()
    {
        CallbackHandler.instance.updateMoney -= UpdateMoney;
    }
    #endregion Callbacks

    void UpdateMoney(int _money)
    {
        text.SetText("$" + _money.ToString());
    }
}
