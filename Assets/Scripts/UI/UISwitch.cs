using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwitch : MonoBehaviour
{
    [HideInInspector] public UISwitchPuzzle parent;
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        int rand = Random.Range(0, 2);
        on = rand > 0;
        image.sprite = on ? onSprite : offSprite;
    }

    public bool on;
    public Sprite onSprite;
    public Sprite offSprite;
    public List<UISwitch> adjacent;

    public void Toggle()
    {
        ToggleMe();
        ToggleNearby();
    }

    public void ToggleMe()
    {
        on = !on;
        image.sprite = on ? onSprite : offSprite;
    }

    public void ToggleNearby()
    {
        foreach(UISwitch n in adjacent)
        {
            n.ToggleMe();
        }
        parent.Check();
    }
}
