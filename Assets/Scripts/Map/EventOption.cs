using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventOption", menuName = "Events/EventOption", order = 1)]
public class EventOption : ScriptableObject
{
    public string text;
    public Event completionEvent;
    public Rewards rewards;
}