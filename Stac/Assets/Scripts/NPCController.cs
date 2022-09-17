using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public enum NPCType
    {
        Bottle,     //������
        Box,        //��Ƽ����
        ETC         //��Ÿ
    }

    public NPCType myType;

    PlayerController player;
    public GameObject talkIcon;

    public float activationDistance = 2.2f;
    bool isActivation;
    bool isTalkingBefore;

    [SerializeField]
    string[] sentences;
    void Start()
    {
        player = GameObject.FindWithTag("Player")?.GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position,player.transform.position) <= activationDistance)
        {
            isActivation = true;
            talkIcon.SetActive(true);
        }
        else
        {
            isActivation = false;
            talkIcon.SetActive(false);
        }
    }

    private void OnMouseDown()  
    {
        if (isActivation && !isTalkingBefore)
        {
            isTalkingBefore = true;
            DialogManager.Instance.Ondialogue(sentences);
            CheckItem();
        }
    }

    void CheckItem()
    {
        switch (myType)
        {
            case NPCType.Bottle:   
                break;
            case NPCType.Box:
                break;
            case NPCType.ETC:
                break;
            default:
                break;
        }
    }

}
