using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            UIHandler.instance.ToggleRotatePuzzle(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            UIHandler.instance.ToggleRotatePuzzle(false);
        }
    }
}
