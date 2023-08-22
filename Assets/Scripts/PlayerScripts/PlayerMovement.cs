using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float crouchSpeedMultiplier = 0.5f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isCrouching = false;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 좌우 이동
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }

        if (isCrouching)
        {
            moveHorizontal *= crouchSpeedMultiplier;
        }

        rb.velocity = new Vector2(moveHorizontal * movementSpeed, rb.velocity.y);

        // 좌우 방향 설정
        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveHorizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // 점프
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 숙이기
        if (Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
        }

        // 애니메이션 설정
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        animator.SetBool("IsCrouching", isCrouching);
        animator.SetBool("IsJumping", !isGrounded); // 점프 중에도 점프 애니메이션 재생
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 바닥과의 충돌 감지
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥과의 충돌 종료 감지
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
