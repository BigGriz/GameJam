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

    public void LoadScene(string _scene)
    {
        SceneManager.LoadScene(_scene, LoadSceneMode.Additive);
        map.SetActive(false);
    }

    public void MapComplete()
    {
        CallbackHandler.instance.KillProjectiles();
        SceneManager.UnloadSceneAsync(1);
        map.SetActive(true);
    }
}
