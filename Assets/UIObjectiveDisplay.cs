using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectiveDisplay : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    float fadeTimer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // pass through text here
    }

    // Update is called once per frame
    void Update()
    {
        fadeTimer -= Time.deltaTime;
        text.color = new Color(1.0f, 1.0f, 1.0f, fadeTimer);
    }
}
