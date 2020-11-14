using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Setup & Callbacks
    private void Start()
    {
        CallbackHandler.instance.killProjectiles += KillProjectile;
        // Temp
        projStats.lifetime = 3.0f;
    }
    private void OnDestroy()
    {
        CallbackHandler.instance.killProjectiles -= KillProjectile;
    }
    #endregion Setup & Callbacks

    public ProjectileStats projStats;
    public void KillProjectile()
    {
        Destroy(this.gameObject);
    }

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
        projStats.lifetime -= Time.deltaTime;
        if (projStats.lifetime <= 0)
        {
            KillProjectile();
        }
    }
}
