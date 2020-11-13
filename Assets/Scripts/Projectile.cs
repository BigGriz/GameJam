using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileStats projStats;

    private void OnCollisionEnter(Collision collision)
    {

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(projStats.damage);
            Destroy(this.gameObject);
        }

        PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
        if (player)
        {

            player.TakeDamage(projStats.damage);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.position += transform.forward * projStats.speed * Time.deltaTime;
    }
}
