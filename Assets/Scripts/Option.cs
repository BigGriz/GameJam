using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    EventOption option;

    public void Setup(EventOption _option)
    {
        option = _option;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(option.text);
    }

    public void Setup()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText("Continue");
    }
}
