using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAgent : MonoBehaviour
{
    public void KillMe()
    {
        Destroy(this.transform.root.gameObject);
    }
}
