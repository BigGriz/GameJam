using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void StartGame()
    {
        Fader.instance.storedFunc += LoadScene;
        Fader.instance.FadeOut();
    }

    public void LoadScene()
    {
        Fader.instance.storedFunc -= LoadScene;
        SceneManager.LoadScene("MapScene");
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
