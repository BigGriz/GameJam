using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public UpgradeType upgrade;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();

        if (player)
        {
            // Change to skillslot later
            CallbackHandler.instance.UpgradeSkill(0, upgrade);
            Destroy(this.gameObject);
        }
    }
}
