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

    public float activationDistance = 3f;
    bool isActivation;
    bool isTalkingBefore;

    [SerializeField]
    string[] sentences;
    [SerializeField] string[] endSentence;   //��ȭ�� ������ �� �ٽ� ��ȭ


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
        if (isActivation)
        {

            string[] s = null;

            if (isTalkingBefore)
                s = endSentence;
            else 
                s = sentences;

            DialogManager.Instance.Ondialogue(s);
            CheckItem();
        }
    }

    void CheckItem()
    {
        switch (myType)
        {
            case NPCType.Bottle:
                player.bottle.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case NPCType.Box:
                player.Styrofoam.SetActive(true);
                gameObject.SetActive(false);
                break;
            case NPCType.ETC:
                isTalkingBefore = true;
                break;
            default:
                break;
        }
    }

}
