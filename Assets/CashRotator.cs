using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 200 * Time.deltaTime);
        transform.localScale = Vector3.one * (Mathf.PingPong(Time.time, 0.5f) + 0.6f);
    }
}
