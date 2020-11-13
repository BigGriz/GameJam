using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMana : MonoBehaviour
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
        UIHandler.instance.updateMana += UpdateMana;
    }
    private void OnDestroy()
    {
        UIHandler.instance.updateMana -= UpdateMana;
    }
    #endregion Callbacks

    void UpdateMana(float _mana)
    {
        image.fillAmount = _mana;
    }
}
