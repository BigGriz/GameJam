using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    #region Setup
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    #endregion Setup
    #region Callbacks
    void Start()
    {
        UIHandler.instance.updateHealth += UpdateHealth;
    }
    private void OnDestroy()
    {
        UIHandler.instance.updateHealth -= UpdateHealth;
    }
    #endregion Callbacks

    void UpdateHealth(float _health)
    {
        image.fillAmount = _health;
    }
}
