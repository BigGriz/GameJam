using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLayer : MonoBehaviour
{
    public GameObject nodePrefab;

    private void Start()
    {
        int rand = Random.Range(2, 5);
        
        for (int i = 0; i < rand; i++)
        {
            Instantiate(nodePrefab, this.transform);
        }
    }
}
