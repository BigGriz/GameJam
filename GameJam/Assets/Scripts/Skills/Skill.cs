using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProjectileStats
{
    public float damage;
    public float speed;
}

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill", order = 1)]
public class Skill : ScriptableObject
{
    // Projectile Arc - Math?
    int[] oddArray = { 0, -10, 10, -20, 20 };
    int[] evenArray = { -10, 10, -20, 20, 30, -30 };

    public Sprite image;
    public GameObject projectile;
    public ProjectileStats stats;

    public float manaCost;
    public float cooldown;
    public float maxCooldown;
    public float numProjectiles;

    public void Use()
    {
        if (cooldown <= 0)
        {
            PlayerStats player = PlayerStats.instance;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
            {
                Vector3 tempPoint = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);

                // check loaded type - if direction
                player.transform.LookAt(hit.point);

                int[] angleArray = (numProjectiles % 2 == 0) ? evenArray : oddArray;

                for (int i = 0; i < numProjectiles; i++)
                {
                    Projectile temp = Instantiate(projectile, player.transform.position + player.transform.forward, Quaternion.identity).GetComponent<Projectile>();
                    Physics.IgnoreCollision(temp.GetComponent<Collider>(), player.GetComponent<Collider>());
                    temp.transform.rotation = Quaternion.Euler(0.0f, player.transform.rotation.eulerAngles.y + angleArray[i], 0.0f);
                    temp.projStats = stats;
                }
            }

            cooldown = maxCooldown;
        }
    }

    public void UpdateCooldown(float _time)
    {
        cooldown -= (cooldown > 0) ? _time : cooldown;
    }
}
