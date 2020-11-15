using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Event", menuName = "Events/Event", order = 1)]
public class Event : ScriptableObject
{
    public Sprite sprite;
    public string description;
    public List<EventOption> options;
}