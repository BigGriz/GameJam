using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISwitchPuzzle : MonoBehaviour
{
    UISwitch[] switches;
    public bool solved;
    private void Awake()
    {
        switches = GetComponentsInChildren<UISwitch>();
        foreach(UISwitch n in switches)
        {
            n.parent = this;
        }
    }

    public void Check()
    {
        if (CheckComplete())
        {
            Complete();
        }
        // Else do nothing
    }

    public bool CheckComplete()
    {
        foreach(UISwitch n in switches)
        {
            if (!n.on)
            {
                return false;
            }
        }
        return true;
    }

    public void Complete()
    {
        foreach (UISwitch n in switches)
        {
            n.enabled = false;
            n.GetComponent<Button>().enabled = false;
        }
        solved = true;

        if (EnemySpawner.instance.type == GameType.Puzzle)
        {
            MapController.instance.MapComplete();
        }
        // Open door or w.e
    }
}
