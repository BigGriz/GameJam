using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRotatePuzzle : MonoBehaviour
{
    public bool solved;

    RotatePuzzle[] puzzlePieces;
    private void Awake()
    {
        puzzlePieces = GetComponentsInChildren<RotatePuzzle>();
        foreach(RotatePuzzle n in puzzlePieces)
        {
            n.parent = this;
        }
    }

    public void Check()
    {
        if (CheckComplete())
        {
            foreach (RotatePuzzle n in puzzlePieces)
            {
                n.enabled = false;
                n.GetComponent<Button>().enabled = false;
            }
            solved = true;
        }
    }

    public bool CheckComplete()
    {
        foreach(RotatePuzzle n in puzzlePieces)
        {
            if (n.important && (n.correctRot != n.currentRot))
            {
                return false;
            }
        }
        return true;
    }
}
