using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

    RectTransform RT;
    Vector3 size;
    [SerializeField]
    GameObject touchEffect;
    [SerializeField]
    Canvas gameCanvas;

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
