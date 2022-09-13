using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isFindPlayer; // ���� ���� �÷��̾ ������ ��

    Transform playerTransform; // �÷��̾� ��ġ

    [SerializeField] GameObject particle;   //���� ���� ȿ�� ����Ʈ ������Ʈ

    public Transform PlayerTransform
    {
        get { return playerTransform; }
        set { playerTransform = value; }
    }
     
    void Update()
    {
        FollowPlayer();
    }

    /// <summary>
    /// �÷��̾ �Ѿư��� �Լ�
    /// </summary>
    void FollowPlayer()
    {
        if (isFindPlayer)
        {
            if (playerTransform.position.x > transform.position.x)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.right);
            }
            else if (playerTransform.position.x < transform.position.x)
            {
                transform.Translate(speed * Time.deltaTime * Vector2.left);
            }
        }
    }

    public void Dead()
    {
        GameObject go = Instantiate(particle,transform.position,Quaternion.identity);
        Destroy(go, 1f);

        Destroy(gameObject);
    }
}
