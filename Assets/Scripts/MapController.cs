using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public static MapController instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one MapController exists!");
            Destroy(this.gameObject);
        }
        instance = this;
    }

    public GameObject map;
    string scene;

    public void ReturnToMain()
    {
        scene = "MainMenu";
        Fader.instance.storedFunc += MainMenu;
        Fader.instance.FadeOut();
    }

    public void MainMenu()
    {
        Fader.instance.storedFunc -= MainMenu;
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string _scene)
    {
        scene = _scene;
        Fader.instance.storedFunc += StoredLoad;
        Fader.instance.FadeOut();
    }

    public void StoredLoad()
    {
        Fader.instance.storedFunc -= StoredLoad;
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        map.SetActive(false);
    }

    public void MapComplete()
    {
        CallbackHandler.instance.KillProjectiles();
        SceneManager.UnloadSceneAsync(1);
        map.SetActive(true);
    }
}
