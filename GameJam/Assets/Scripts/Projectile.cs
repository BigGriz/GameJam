using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileStats projStats;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.position += transform.forward * projStats.speed * Time.deltaTime;
    }
}
