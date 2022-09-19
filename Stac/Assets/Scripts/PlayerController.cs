using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed; // 속도
    [SerializeField] private float jumpForce; // 점프력

    [SerializeField] private KeyCode jumpKey; // 점프 키

    [SerializeField] private Slider moveSlider; // 움직임 슬라이더

    [SerializeField] private GameObject deadPanel; // 죽음 패널
    [SerializeField] private GameObject shadow; // 그림자

    [SerializeField] private Transform spawnPoint; // 죽음 스폰 포인트

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;

    bool isDead;
    public bool canAttack;
    bool isJump;


    [Header("Sound")]
    public AudioClip footstepClip;
    public AudioClip jumpClip;
    public AudioClip attackClip;

    [Header("Item")]
    public AttackBottle bottle;
    public GameObject Styrofoam;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = spawnPoint.position;
        StartCoroutine(footstepCo());
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        Move();
        Jump();
    }

    /// <summary>
    /// 움직임
    /// </summary>
    private void Move()
    {
        

        rb2D.velocity = new Vector2(moveSlider.value * speed, rb2D.velocity.y);

        spriteRenderer.flipX = moveSlider.value > 0;

        animator.SetBool("isWalk", moveSlider.value != 0);
    }

    IEnumerator footstepCo()
    {

        while (true)
        {
            yield return null;

            if (moveSlider.value != 0 && !isJump)
            {
                SoundManager.Instance.SFXPlay("footstep", footstepClip);
            }

            yield return new WaitForSeconds(0.55f);
        }
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
            SoundManager.Instance.SFXPlay("Jump",jumpClip);
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
        isDead = true;
        StartCoroutine(DeadDelay());
    }

    private IEnumerator DeadDelay()
    {
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(0.3f);
        deadPanel.SetActive(true);
        transform.position = spawnPoint.position;
        yield return new WaitForSeconds(1f);
        isDead = false;
        deadPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            shadow.SetActive(true);
            isJump = false;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Dead();
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 1 ? 0 : 1);
        }
        else if (collision.gameObject.CompareTag("deadLine"))
        {
            if (Styrofoam.activeSelf == false)
                Dead();
        }
        else if (collision.gameObject.CompareTag("EndWall"))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            shadow.SetActive(false);
        }
    }
}


