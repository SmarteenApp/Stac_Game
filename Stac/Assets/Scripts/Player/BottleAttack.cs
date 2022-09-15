using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BottleAttack : MonoBehaviour
{
    Rigidbody2D playerRigid;
    Animator anim;
    bool isAttack;  //�������� 

    GameObject particle;        //���� ��ƼŬ
    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>().gameObject;
        playerRigid = GetComponentInParent<Rigidbody2D>();
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
            Attack();
        }
        particle.SetActive(isAttack);

    }

    private void FixedUpdate()
    {
        PlayerMoveCheck();
    }

    private void PlayerMoveCheck()
    {
        transform.localPosition = playerRigid.velocity.x < 0 ?
            new Vector3(-0.3f, transform.localPosition.y, transform.localPosition.z) : new Vector3(0.3f, transform.localPosition.y, transform.localPosition.z);
        transform.localScale = playerRigid.velocity.x < 0 ? 
            new Vector3(-1,transform.localScale.y,transform.localScale.z) : new Vector3(1, transform.localScale.y, transform.localScale.z);

    }

    public void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }


    IEnumerator AttackCoroutine()
    {
        isAttack = true;
        anim.SetTrigger("isAttack");
        while (true)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Bottle_Attack") &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) //anim �۵��� �� ������ ��
            {
                isAttack = false;
                yield break;
            }

            yield return new WaitForEndOfFrame();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Monster>(out Monster monster))
        {
            monster.Dead();
        }
    }
}
