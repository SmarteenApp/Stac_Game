using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{

    RectTransform RT;
    Vector3 size;
    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RT.localScale = size * .9f;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RT.localScale = size;
    }

    void Start()
    {
        RT = GetComponent<RectTransform>();

        size = RT.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
