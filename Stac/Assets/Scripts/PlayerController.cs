using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed; // 속도
    [SerializeField] private float jumpForce; // 점프력

    [SerializeField] private KeyCode jumpKey; // 점프 키

    Animator animator;
    Rigidbody2D rb2D;


    bool isWalk;
    bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    /// <summary>
    /// 움직임
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector2(h, 0) * speed * Time.deltaTime);

        isWalk = h != 0;

        animator.SetBool("isWalk", isWalk);
    }

    /// <summary>
    /// 점프
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isJump == false)
        {
            // transform.Translate(new Vector2(0, jumpForce * Time.deltaTime));
            rb2D.AddForce(Vector2.up * jumpForce);
            isJump = true;
            animator.SetTrigger("Jump");
        }
    }

    /// <summary>
    /// 능력
    /// </summary>
    /// <param name="i"></param>
    private void OnAbilityButton(float i)
    {
        animator.SetTrigger("Ability");
        animator.SetFloat("Number", i);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}


