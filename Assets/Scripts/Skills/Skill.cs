using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProjectileStats
{
    public float damage;
    public float speed;
    public float lifetime;
}

public enum UpgradeType
{
    Cooldown,
    NumProj,
    Damage,
    NegCooldown,
    NegNumProj,
    NegDamage,
    None
}

public enum SkillType
{
    Projectile,
    Dash
}

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill", order = 1)]
public class Skill : ScriptableObject
{
    // Projectile Arc - Math?
    int[] oddArray = { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50 };
    int[] evenArray = { -10, 10, -20, 20, -30, 30, -40, 40, -50, 50 };

    public Sprite image;
    public GameObject projectile;
    public ProjectileStats stats;
    public SkillType type;

    public float manaCost;
    public float cooldown;
    public float maxCooldown;
    public float numProjectiles;


    public void Use()
    {
        // Check type of ability for anim - do once others are in
        if (cooldown <= 0)
        {
            PlayerStats player = PlayerStats.instance;
            if (player.dying)
                return;

            switch (type)
            {
                case SkillType.Projectile:
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
                    {
                        Vector3 tempPoint = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);

                        // check loaded type - if direction
                        player.transform.LookAt(hit.point);

                        int[] angleArray = (numProjectiles % 2 == 0) ? evenArray : oddArray;

                        for (int i = 0; i < numProjectiles; i++)
                        {
                            PlayerStats.instance.Shoot();
                            CallbackHandler.instance.StopPlayer();

                            Projectile temp = Instantiate(projectile, player.transform.position + player.transform.forward, Quaternion.identity).GetComponent<Projectile>();
                            Physics.IgnoreCollision(temp.GetComponent<Collider>(), player.GetComponent<Collider>());
                            temp.transform.rotation = Quaternion.Euler(0.0f, player.transform.rotation.eulerAngles.y + angleArray[i], 0.0f);
                            temp.projStats = stats;
                        }
                    }
                    break;
                }
                case SkillType.Dash:
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
                    {
                        Vector3 dir = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
                        CallbackHandler.instance.DashToLocation(dir);
                    }

                    break;
                }
            }

            cooldown = maxCooldown;
        }
    }

    public void UpdateCooldown(float _time)
    {
        cooldown -= (cooldown > 0) ? _time : cooldown;
    }

    public void UpgradeSkill(UpgradeType _upgrade)
    {
        switch(_upgrade)
        {
            case UpgradeType.Cooldown:
            {
                maxCooldown *= 0.66f;
                break;
            }
            case UpgradeType.Damage:
            {
                stats.damage *= 1.50f;
                break;
            }
            case UpgradeType.NumProj:
            {
                numProjectiles += 1;
                break;
            }
            case UpgradeType.NegCooldown:
            {
                maxCooldown /= 0.66f;
                break;
            }
            case UpgradeType.NegDamage:
            {
                stats.damage /= 1.50f;
                break;
            }
            case UpgradeType.NegNumProj:
            {
                if (numProjectiles > 1)
                {
                    numProjectiles -= 1;
                }
                break;
            }
            default:
                break;
        }
    }
}
