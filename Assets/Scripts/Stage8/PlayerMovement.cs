using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 300f;   // 이동 속도
    public float jumpForce = 500f;   // 점프 힘
    public float groundDrag = 4f;    // 땅에서의 마찰력 (감속)
    public float airDrag = 2f;       // 공중에서의 마찰력 (감속)
    public Transform mario;
    public Transform respawnPoint;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    
    public Animator PlayerAnimator;
    private float lastMoveDirection = 1f; // 마지막 움직임 방향 (1: 오른쪽, -1: 왼쪽)
    private float lastState = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // A/D 또는 화살표 좌우키로 이동
        float targetVelocityX = moveInput * moveSpeed;

        // 공중에서의 마찰력
        if (isGrounded)
        {
            // 지면에 있을 때는 땅 마찰력을 적용하여 점진적으로 속도를 감소시킴
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, targetVelocityX, groundDrag * Time.deltaTime), rb.velocity.y);
        }
        else
        {
            // 공중에서는 더 느리게 속도를 감소시킴
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, targetVelocityX, airDrag * Time.deltaTime), rb.velocity.y);
        }

        if (moveInput != 0)
        {
            lastMoveDirection = Mathf.Sign(moveInput); // 방향 업데이트
            if (lastMoveDirection >= 0) PlayerAnimator.SetInteger("state", 1); // 오른쪽 이동 중일 때 스프라이트 변경
            else PlayerAnimator.SetInteger("state", -2); // 왼쪽 이동 중일 때 스프라이트 변경
            lastState = PlayerAnimator.GetInteger("state");
        }
        else
        {
            if (lastMoveDirection >= 0) PlayerAnimator.SetInteger("state", 0); // 멈춰있을 때 오른쪽 상태
            else PlayerAnimator.SetInteger("state", -1); // 멈춰있을 때 왼쪽 상태
            lastState = PlayerAnimator.GetInteger("state");
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) // 점프
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (lastState >= 0)
                PlayerAnimator.SetInteger("state", 2); // 오른쪽 점프 상태
            else
                PlayerAnimator.SetInteger("state", -3); // 왼쪽 점프 상태
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("Death"))
        {
            mario.transform.position = respawnPoint.position;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
