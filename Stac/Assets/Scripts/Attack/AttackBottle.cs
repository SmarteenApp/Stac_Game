using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBottle : MonoBehaviour
{
    Rigidbody2D playerRigid;

    GameObject bottle;
    bool isRight;

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
        Debug.Log(playerRigid.velocity);

        isRight = playerRigid.velocity.x < 0 ? true : false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = isRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

    }

    void Attack()
    {
        
    }
}
