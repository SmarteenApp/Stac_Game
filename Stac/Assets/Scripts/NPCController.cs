using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
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

        }
    }
}
