using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();

        if (player)
        {
            player.TakeDamage(damage);
        }
    }
}
