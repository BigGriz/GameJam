using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void Awake()
    {
        int temp = 0;

        foreach(Transform n in transform)
        {
            n.GetComponent<Skillslot>().skillID = temp;
            temp++;
        }
    }
}
