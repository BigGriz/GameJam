using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    EventOption option;
    UIEvent parent;

    public void Setup(EventOption _option, UIEvent _parent)
    {
        parent = _parent;
        option = _option;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(option.text);
    }

    public void Setup()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText("Continue");
    }

    public void UpdateEvent()
    {  
        // Continue
        if (!option || !option.completionEvent)
        {
            MapController.instance.ToggleEvent(false);
        }
        // Next Step
        else
        {
            CallbackHandler.instance.AddMoney(option.rewards.money);
            parent.Setup(option.completionEvent);
        }
    }
}
