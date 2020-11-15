using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    int money;
    private void Awake()
    {
        money = Random.Range(0, 15);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();

        if (player)
        {
            // Change to skillslot later
            CallbackHandler.instance.AddMoney(money);
            Destroy(this.gameObject);
        }
    }
}
