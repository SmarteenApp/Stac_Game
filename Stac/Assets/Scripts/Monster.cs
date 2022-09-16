using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isFindPlayer; // ���� ���� �÷��̾ ������ ��

    Transform playerTransform; // �÷��̾� ��ġ

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
        Debug.Log("���� ����");
        Destroy(gameObject);
    }
}
