using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed; // 속도
    [SerializeField] private float jumpForce; // 점프력

    [SerializeField] private KeyCode jumpKey; // 점프 키

    [SerializeField] private Slider moveSlider; // 움직임 슬라이더

    [SerializeField] private GameObject deadPanel; // 죽음 패널

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
        transform.Translate(new Vector2(moveSlider.value, 0) * speed * Time.deltaTime);
        animator.SetBool("isWalk", moveSlider.value != 0);
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

    public void OnJumpButton()
    {
        if (isJump == false)
        {
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

    private void Dead()
    {
        deadPanel.SetActive(true);
        transform.position = Vector3.zero;
        StartCoroutine(DeadDelay());
    }

    private IEnumerator DeadDelay()
    {
        yield return new WaitForSeconds(1f);
        deadPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Dead();
        }
    }
}


