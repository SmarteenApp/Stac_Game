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
        var effect = Instantiate(touchEffect, eventData.position, Quaternion.identity);
        effect.transform.parent = gameCanvas.transform;
        Destroy(effect, 0.5f);
    }

    void Start()
    {
        RT = GetComponent<RectTransform>();
        gameCanvas = GameObject.Find("GameCanvas").GetComponent<Canvas>();
        size = RT.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
