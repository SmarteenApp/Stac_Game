using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private KeyCode jumpKey;

    Animator animator;
    Rigidbody2D rb;

    bool isWalk;
    bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector2(h,0) * speed * Time.deltaTime);

        isWalk = h != 0;

        animator.SetBool("isWalk", isWalk);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isJump == false)
        {
            for (int i = 0; i < 10; i++)
                transform.Translate(Vector2.up * jumpForce * Time.deltaTime);
            isJump = true;
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

}


