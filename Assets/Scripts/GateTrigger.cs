using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            UIHandler.instance.ToggleGatePuzzle(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (player)
        {
            UIHandler.instance.ToggleGatePuzzle(false);
        }
    }
}
