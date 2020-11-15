using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollableMap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool dragging;
    float initY;

    public GameObject nodeLayerPrefab;
    public int layers;
    private void Awake()
    {
        /*layers -= 1;
        float height = this.GetComponent<RectTransform>().rect.height - 200;
        for (int i = 0; i <= layers; i++)
        {
            GameObject temp = Instantiate(nodeLayerPrefab, this.transform);
            temp.transform.localPosition = new Vector3(0, height / layers * i - height / 2, 0);
            temp.GetComponent<NodeLayer>().layer = i;
            nodeLayers.Add(temp.GetComponent<NodeLayer>());
        }*/

        int count = 0;

        NodeLayer[] nodeLayers = GetComponentsInChildren<NodeLayer>();
        foreach(NodeLayer n in nodeLayers)
        {
            n.layer = count;
            count++;
        }
    }

    public void Update()
    {
        /*if (dragging)
        {
            float yPos = Mathf.Clamp(Input.mousePosition.y - initY, -720.0f, 720.0f);

            transform.localPosition = new Vector2(0, yPos);
        }*/
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
