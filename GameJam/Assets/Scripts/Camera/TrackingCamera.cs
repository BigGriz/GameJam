using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    private void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}
