using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    bool isAttack;  //공격중임 
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !isAttack)        //키 입력은 추후 UI 연결후 변경
        {
            StartCoroutine(Attack());
        }
    }

   
    IEnumerator Attack()
    {
        isAttack = true;

        anim.SetTrigger("isAttack");
        while (true)
        {
            
            if(anim.GetCurrentAnimatorStateInfo(0).nameHash == "Attack")
            yield return null;

        }

    }

}
