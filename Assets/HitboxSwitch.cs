using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxSwitch : MonoBehaviour
{
    public Collider hitBox;

    private void Start()
    {
        TurnOff();
    }

    public void TurnOn()
    {
        hitBox.enabled = true;
    }

    public void TurnOff()
    {
        hitBox.enabled = false;
    }
}
