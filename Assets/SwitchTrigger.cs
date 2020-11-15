using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            UIHandler.instance.ToggleSwitchPuzzle(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            UIHandler.instance.ToggleSwitchPuzzle(false);
        }
    }
}
