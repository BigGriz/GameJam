using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour
{
    [HideInInspector] public UIRotatePuzzle parent;
    public bool important;
    public bool line;

    private void Awake()
    {
        int rand = Random.Range(0, 5);
        currentRot = rand * 90.0f;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRot));

        if (line && currentRot > 90)
        {
            currentRot -= 180;
        }
        if (currentRot >= 360)
        {
            currentRot -= 360;
        }
    }

    [HideInInspector] public float currentRot;
    public float correctRot;

    public void Rotate()
    {
        currentRot += 90;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, currentRot));

        if (line && currentRot > 90)
        {
            currentRot -= 180;
        }
        if (currentRot >= 360)
        {
            currentRot -= 360;
        }

        parent.Check();
    }
}
