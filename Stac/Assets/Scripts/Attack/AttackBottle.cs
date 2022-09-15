using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBottle : MonoBehaviour
{
    Rigidbody2D playerRigid;

    bool isRight;
    bool isAttack;      //���� ���ΰ�?

    private void Awake()
    {
        playerRigid = GetComponentInParent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        isRight = playerRigid.velocity.x < 0 ? false : true;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = isRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);



        if (Input.GetKeyDown(KeyCode.Q) && !isAttack)    //����Ű, ���� ���� ����
        {
            StartCoroutine(Attack());
            
        }
    }

    float timer;
    float attackTime = 0.3f;   //���� ��Ž
    IEnumerator Attack()
    {
        Vector3 attckVec = new Vector3(0, 0, -60);
        timer = 0;
        isAttack = true;

        while (true)
        {
            timer += Time.deltaTime;
            transform.Rotate(attckVec * 30f * Time.deltaTime);

            if(timer > attackTime)
            {
                transform.localRotation = Quaternion.identity;
                isAttack=false;
                yield break;
            }
            
            
            yield return new WaitForEndOfFrame();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Monster>(out Monster monster))
        {
            Debug.Log(monster.gameObject.name);
            monster.Dead();
            Debug.Log("���� ����");
        }
    }
}
