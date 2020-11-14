﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RoomType
{
    Basic,
    Elite,
    Event,
    Treasure,
    Shop,
    Campfire,
    Boss
}

public class Node : MonoBehaviour
{
    public RoomType type;
    public Sprite[] sprite;
    public GameObject complete;
    [HideInInspector] public bool completed;
    [HideInInspector] public bool disabled;
    public int layer;

    public List<Node> links;

    // Setup
    private void Awake()
    {
        Image image = GetComponent<Image>();
        image.sprite = sprite[(int)type];
        complete.SetActive(completed);
    }

    public bool CheckLinks()
    {
        if (links.Count == 0)
        {
            return true;
        }

        foreach (Node n in links)
        {
            // Only allow if a previous room is completed
            if (n.completed)
            {
                return true;
            }
        }
        return false;
    }

    public void EnterRoom()
    {
        if (!disabled && CheckLinks())
        {
            completed = true;
            complete.SetActive(completed);
            CallbackHandler.instance.DisableLayer(layer);
            MapController.instance.LoadScene("TestScene");
        }
    }
}