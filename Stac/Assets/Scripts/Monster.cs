using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isRigit;        //�̵� ���� ��


    private void Start()
    {
        StartCoroutine(MoveDirection());
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVec = isRigit ? Vector2.right : Vector2.left;

        transform.Translate(moveVec * speed * Time.deltaTime);
    }

    IEnumerator MoveDirection()
    {
        while (true)
        {
            isRigit = false;
            yield return new WaitForSeconds(3f);
            isRigit = true;
            yield return new WaitForSeconds(3f);

        }


    }

    public void Dead()
    {
        Debug.Log("���� ����");
        Destroy(gameObject);
    }
}
