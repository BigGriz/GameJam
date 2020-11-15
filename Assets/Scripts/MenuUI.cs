using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        ToggleMenu(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(!menu.activeSelf);
        }
    }

    public void ToggleMenu(bool _toggle)
    {
        menu.SetActive(_toggle);
        Time.timeScale = (_toggle) ? 0 : 1;
    }

    public void Resume()
    {
        ToggleMenu(false);
    }

    public void Options()
    {

    }

    public void MainMenu()
    {
        Fader.instance.storedFunc += LoadMainMenu;
        ToggleMenu(false);
        Fader.instance.FadeOut();
    }

    public void LoadMainMenu()
    {
        Fader.instance.storedFunc -= LoadMainMenu;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
