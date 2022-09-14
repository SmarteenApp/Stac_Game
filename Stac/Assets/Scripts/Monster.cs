using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isFindPlayer; // 범위 내에 플레이어가 들어왔을 때

    Transform playerTransform; // 플레이어 위치

    [SerializeField] GameObject particle;   //죽은 다음 효과 이팩트 오브젝트

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
    /// 플레이어를 쫓아가는 함수
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
