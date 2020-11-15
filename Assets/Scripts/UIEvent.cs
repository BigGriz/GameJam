using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour
{
    public Image image;
    public TMPro.TextMeshProUGUI description;
    // Change this
    public GameObject options;
    public GameObject optionPrefab;

    public void Setup(Event _event)
    {
        image.sprite = _event.sprite;
        description.SetText(_event.description);

        foreach(EventOption n in _event.options)
        {
            Option temp = Instantiate(optionPrefab, options.transform).GetComponent<Option>();
            temp.Setup(n);
        }
    }

    public void Setup(Rewards _reward)
    {
        //image.sprite = _event.sprite;
        description.SetText("You find $" + _reward.money + " while scavenging.");
        Option temp = Instantiate(optionPrefab, options.transform).GetComponent<Option>();
        temp.Setup();        
    }
}
