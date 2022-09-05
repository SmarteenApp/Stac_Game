using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAttack : MonoBehaviour
{
    Animator anim;
    bool isAttack;  //�������� 
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
        if(Input.GetKeyDown(KeyCode.P) && !isAttack)        //Ű �Է��� ���� UI ������ ����
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
            
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Bottle_Attack")&&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) //anim �۵��� �� ������ ��
            {
                isAttack = false;
                yield break;
            }
                
            yield return new WaitForEndOfFrame();

        }

    }

}
