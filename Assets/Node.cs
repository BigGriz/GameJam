using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    Basic,
    Horde,
    Elite,
    Event,
    Treasure,
    Boss
}

public class Node : MonoBehaviour
{
    public RoomType type;
    // Setup

    public void EnterRoom()
    {
        Debug.Log("Entering " + type.ToString() + " room.");
    }
}
