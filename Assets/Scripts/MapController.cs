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

        ToggleEvent(false);
        shop.SetActive(false);
    }

    public GameObject map;
    public UIEvent ev;
    public GameObject shop;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            MapComplete();
        }
    }

    public void MapComplete()
    {
        CallbackHandler.instance.KillProjectiles();
        SceneManager.UnloadSceneAsync("TestScene");
        map.SetActive(true);
    }

    public void PlayEvent(Event _event)
    {
        ev.gameObject.SetActive(true);
        ev.Setup(_event);
    }
    public void PlayEvent(Rewards _rewards)
    {
        ev.gameObject.SetActive(true);
        ev.Setup(_rewards);
    }

    public void ToggleShop(bool _toggle)
    {
        shop.SetActive(_toggle);
    }

    public void ToggleEvent(bool _toggle)
    {
        ev.gameObject.SetActive(_toggle);
    }
}
