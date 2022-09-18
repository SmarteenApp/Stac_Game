using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] private float speed;
    public bool isRigit;        //�̵� ���� ��

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(MoveDirection());
    }


    void Update()
    {
        sprite.flipX = isRigit ? false : true;
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
