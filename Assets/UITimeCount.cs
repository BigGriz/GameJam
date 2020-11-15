using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimeCount : MonoBehaviour
{
    #region Setup & Callbacks
    TMPro.TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        //UIHandler.instance.setCount += SetCount;
    }
    private void OnDestroy()
    {
        //UIHandler.instance.setCount -= SetCount;
    }
    #endregion Setup & Callbacks

    float time = 60.0f;
    private void Update()
    {
        if (PlayerStats.instance.init)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            MapController.instance.MapComplete();
        }

        text.SetText("Time Remaining: " + ((int)time).ToString());
    }
}
