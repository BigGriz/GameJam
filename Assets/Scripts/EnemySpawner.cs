using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameType
{
    Eliminate,
    Survive,
    Puzzle
}

public class EnemySpawner : MonoBehaviour
{
    public GameType type;
    float timer;

    List<GameObject> spawnPlanes;

    public GameObject meleeEnemyPrefab;
    public GameObject rangedEnemyPrefab;
    public GameObject bossEnemyPrefab;

    private void Awake()
    {
        spawnPlanes = new List<GameObject>();

        foreach (Transform n in transform)
        {
            spawnPlanes.Add(n.gameObject);
        }
    }

    private void Start()
    {
        switch (type)
        {
            case GameType.Eliminate:
            {

                foreach (GameObject n in spawnPlanes)
                {
                    int rand = Random.Range(0, 4);
                    for (int i = 0; i < rand; i++)
                    {
                        float randomX = Random.Range(n.transform.position.x - n.transform.localScale.x / 2, n.transform.position.x + n.transform.localScale.x / 2);
                        float randomZ = Random.Range(n.transform.position.z - n.transform.localScale.z / 2, n.transform.position.z + n.transform.localScale.z / 2);
                        Vector3 pos = new Vector3(randomX, 0, randomZ);
                        Instantiate(meleeEnemyPrefab, pos, Quaternion.identity);
                    }
                    rand = Random.Range(0, 3);
                    for (int i = 0; i < rand; i++)
                    {
                        float randomX = Random.Range(n.transform.position.x - n.transform.localScale.x / 2, n.transform.position.x + n.transform.localScale.x / 2);
                        float randomZ = Random.Range(n.transform.position.z - n.transform.localScale.z / 2, n.transform.position.z + n.transform.localScale.z / 2);
                        Vector3 pos = new Vector3(randomX, 0, randomZ);
                        Instantiate(rangedEnemyPrefab, pos, Quaternion.identity);
                    }
                }
                break;
            }
            default:
                break;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            switch (type)
            {
                case GameType.Survive:
                {
                    foreach (GameObject n in spawnPlanes)
                    {
                        int rand = Random.Range(0, 3);
                        for (int i = 0; i < rand; i++)
                        {
                            float randomX = Random.Range(n.transform.position.x - n.transform.localScale.x / 2, n.transform.position.x + n.transform.localScale.x / 2);
                            float randomZ = Random.Range(n.transform.position.z - n.transform.localScale.z / 2, n.transform.position.z + n.transform.localScale.z / 2);
                            Vector3 pos = new Vector3(randomX, 0, randomZ);
                            Instantiate(meleeEnemyPrefab, pos, Quaternion.identity).GetComponent<Enemy>().IncreaseAggro();
                        }
                        rand = Random.Range(0, 2);
                        for (int i = 0; i < rand; i++)
                        {
                            float randomX = Random.Range(n.transform.position.x - n.transform.localScale.x / 2, n.transform.position.x + n.transform.localScale.x / 2);
                            float randomZ = Random.Range(n.transform.position.z - n.transform.localScale.z / 2, n.transform.position.z + n.transform.localScale.z / 2);
                            Vector3 pos = new Vector3(randomX, 0, randomZ);
                            Instantiate(rangedEnemyPrefab, pos, Quaternion.identity).GetComponent<Enemy>().IncreaseAggro();
                        }
                    }
                    break;
                }
                default:
                    break;
            }
            timer = 10.0f;
        }
    }
}
