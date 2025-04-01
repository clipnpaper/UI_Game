using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f; // 공의 속도
    private Vector2 ballDirection;
    private Rigidbody2D rb;
    private Vector2 paddlePrevPos; // 패들의 이전 위치
    private float paddleSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballDirection = new Vector2(1f, -1f).normalized; // 초기 공의 방향
        paddlePrevPos = transform.position; // 패들의 초기 위치
    }

    void Update()
    {
        transform.Translate(ballDirection * speed * Time.deltaTime); // 공 이동
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽돌과 충돌 시 벽돌 제거
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            Vector2 normal = collision.contacts[0].normal;
            ballDirection = Vector2.Reflect(ballDirection, normal); 
        }

        // 공이 벽이나 패들과 충돌 시 반사
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            ballDirection = Vector2.Reflect(ballDirection, normal); // 벽에서 반사
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            // 패들의 현재 속도 계산
            paddleSpeed = (transform.position.x - paddlePrevPos.x) / Time.deltaTime;

            // 패들과 충돌 시 반사 벡터 계산
            Vector2 normal = collision.contacts[0].normal;
            ballDirection = Vector2.Reflect(ballDirection, normal); // 기본 반사

            // 패들의 속도에 따라 공의 X 속도에 영향을 줌
            float paddleImpact = paddleSpeed * 0.1f; // 패들의 속도에 비례한 영향

            ballDirection.x += paddleImpact; // 패들의 속도가 공의 X 방향에 미치는 영향

            // 공의 X 방향이 너무 커지지 않도록 제한
            if (ballDirection.x > 1f) ballDirection.x = 1f;
            if (ballDirection.x < -1f) ballDirection.x = -1f;

            // 패들의 위치 업데이트
            paddlePrevPos = transform.position;
        }
    }
}