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

    //[HideInInspector]
    public List<Option> optionList;

    public void Setup(Event _event)
    {
        image.sprite = _event.sprite;
        description.SetText(_event.description);

        foreach(Option n in optionList)
        {
            Destroy(n.gameObject);
        }
        optionList.Clear();

        foreach (EventOption n in _event.options)
        {
            Option temp = Instantiate(optionPrefab, options.transform).GetComponent<Option>();
            temp.Setup(n, this);
            optionList.Add(temp);
        }
    }

    public void Setup(Rewards _reward)
    {
        foreach (Option n in optionList)
        {
            Destroy(n.gameObject);
        }
        optionList.Clear();
        //image.sprite = _event.sprite;
        description.SetText("You find $" + _reward.money + " while scavenging.");
        Option temp = Instantiate(optionPrefab, options.transform).GetComponent<Option>();
        temp.Setup();
        optionList.Add(temp);
    }
}
