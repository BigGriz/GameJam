using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndScreen : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            MainMenu();
        }
    }

    public void MainMenu()
    {
        MapController.instance.MainMenu();
    }
}
