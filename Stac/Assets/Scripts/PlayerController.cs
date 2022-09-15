using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed; // �ӵ�
    [SerializeField] private float jumpForce; // ������

    [SerializeField] private KeyCode jumpKey; // ���� Ű

    [SerializeField] private Slider moveSlider; // ������ �����̴�

    [SerializeField] private GameObject deadPanel; // ���� �г�
    [SerializeField] private GameObject shadow; // �׸���

    [SerializeField] private Transform spawnPoint; // ���� ���� ����Ʈ

    Animator animator;
    Rigidbody2D rb2D;

    public bool canAttack;
    bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    /// <summary>
    /// ������
    /// </summary>
    private void Move()
    {
        transform.Translate(new Vector2(moveSlider.value, 0) * speed * Time.deltaTime);
        animator.SetBool("isWalk", moveSlider.value != 0);
    }

    /// <summary>
    /// ����
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
    /// �ɷ�
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
        transform.position = spawnPoint.position;
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
            shadow.SetActive(true);
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Dead();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 1 ? 0 : 1);
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


