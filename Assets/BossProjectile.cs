using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public GameObject chainsaw;
    // Update is called once per frame
    void Update()
    {
        chainsaw.transform.Rotate(new Vector3(100 * Time.deltaTime, 0, 1000 * Time.deltaTime));
    }
}
