using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollableMap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool dragging;
    float initY;

    public void Update()
    {
        if (dragging)
        {
            float yPos = Mathf.Clamp(Input.mousePosition.y - initY, -720.0f, 720.0f);

            transform.localPosition = new Vector2(0, yPos);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        initY = Input.mousePosition.y - transform.localPosition.y;

        dragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
