using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGatePuzzle : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    string displayedText;
    public string correctAnswer;
    public bool solved;

    UIGateButton[] buttons;
    public GameObject door;
    private void Awake()
    {
        buttons = GetComponentsInChildren<UIGateButton>();
        for (int i = 1; i <= buttons.Length; i++)
        {
            buttons[i - 1].SetButton(i);
            buttons[i - 1].parent = this;
        }
    }

    private void Start()
    {
        Clear();
    }

    public void AddCharacter(string _char)
    {
        if (text.text.Length <= 6)
        {
            displayedText += _char;
            text.SetText(displayedText);
        }
    }

    public void Enter()
    {
        if (displayedText == correctAnswer)
        {
            UIHandler.instance.ToggleGatePuzzle(false);
            solved = true;
            Debug.Log("Correct!");
            door.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    public void Clear()
    {
        displayedText = "";
        text.SetText(displayedText);
    }
}
