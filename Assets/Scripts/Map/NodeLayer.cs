using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLayer : MonoBehaviour
{
    //public GameObject nodePrefab;
    public int layer;
    public Node[] nodes;

    private void Start()
    {
        nodes = GetComponentsInChildren<Node>();
        foreach(Node n in nodes)
        {
            n.layer = layer;
        }

        /*int rand = Random.Range(2, 5);
        
        for (int i = 0; i < rand; i++)
        {
            Instantiate(nodePrefab, this.transform);
        }*/

        CallbackHandler.instance.disableLayer += DisableLayer;
    }

    private void OnDestroy()
    {
        CallbackHandler.instance.disableLayer -= DisableLayer;
    }



    public void DisableLayer(int _layer)
    {
        if (_layer == layer)
        {
            foreach(Node n in nodes)
            {
                n.disabled = true;
            }
        }
    }
}
