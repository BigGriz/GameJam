using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGateButton : MonoBehaviour
{
    int button;
    [HideInInspector] public UIGatePuzzle parent;

    public void SetButton(int _button)
    {
        button = _button;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(_button.ToString());
    }

    public void PressButton()
    {
        parent.AddCharacter(button.ToString());
    }
}
