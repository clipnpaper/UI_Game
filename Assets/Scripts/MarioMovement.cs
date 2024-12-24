using UnityEngine;
using UnityEngine.UI;

public class MarioMovement : MonoBehaviour
{
    public float moveSpeed = 200f;  // 좌우 이동 속도
    public float jumpForce = 300f; // 점프 힘

    // 스프라이트 설정
    public Sprite idleSpriteRight;           // 서 있는 이미지 (오른쪽)
    public Sprite idleSpriteLeft;            // 서 있는 이미지 (왼쪽)
    public Sprite jumpingSpriteRight;        // 점프 이미지 (오른쪽)
    public Sprite jumpingSpriteLeft;         // 점프 이미지 (왼쪽)
    public Sprite[] runningSpritesRight;     // 달리기 이미지 배열 (오른쪽)
    public Sprite[] runningSpritesLeft;      // 달리기 이미지 배열 (왼쪽)

    private RectTransform rectTransform;
    private Image marioImage;
    private bool isJumping = false;
    private bool isRunning = false;
    private int runningSpriteIndex = 0;
    private bool facingRight = true; // 마지막 방향 (오른쪽 = true, 왼쪽 = false)

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        marioImage = GetComponent<Image>();
    }

    void Update()
    {
        // 좌우 입력값 가져오기
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // -1, 0, 1로만 반환

        // 좌우 이동
        if (horizontalInput > 0) // 오른쪽 이동
        {
            facingRight = true;
            rectTransform.anchoredPosition += new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0);

            if (!isRunning && !isJumping)
            {
                isRunning = true;
                StartCoroutine(RunAnimation(runningSpritesRight)); // 오른쪽 달리기 애니메이션 시작
            }
        }
        else if (horizontalInput < 0) // 왼쪽 이동
        {
            facingRight = false;
            rectTransform.anchoredPosition += new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0);

            if (!isRunning && !isJumping)
            {
                isRunning = true;
                StartCoroutine(RunAnimation(runningSpritesLeft)); // 왼쪽 달리기 애니메이션 시작
            }
        }
        else
        {
            isRunning = false; // 달리기 멈춤
        }

        // 멈출 때 기본 스프라이트 전환
        if (!isRunning && !isJumping)
        {
            marioImage.sprite = facingRight ? idleSpriteRight : idleSpriteLeft;
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            isRunning = false; // 점프 중에는 달리기 멈춤
            marioImage.sprite = facingRight ? jumpingSpriteRight : jumpingSpriteLeft; // 방향에 따른 점프 이미지
            StartCoroutine(Jump());
        }
    }

    private System.Collections.IEnumerator Jump()
    {
        float initialY = rectTransform.anchoredPosition.y; // 점프 시작 위치
        float peakY = initialY + 100f; // 점프 최고점
        float speed = jumpForce * Time.deltaTime;

        // 점프 상승
        while (rectTransform.anchoredPosition.y < peakY)
        {
            rectTransform.anchoredPosition += new Vector2(0, speed);
            yield return null;
        }

        // 점프 하강
        while (rectTransform.anchoredPosition.y > initialY)
        {
            rectTransform.anchoredPosition -= new Vector2(0, speed);
            yield return null;
        }

        // 위치 보정
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, initialY);
        isJumping = false;
        marioImage.sprite = facingRight ? idleSpriteRight : idleSpriteLeft; // 점프 후 서 있는 이미지로 복구
    }

    private System.Collections.IEnumerator RunAnimation(Sprite[] runningSprites)
    {
        while (isRunning)
        {
            // Sprite 순환 변경
            marioImage.sprite = runningSprites[runningSpriteIndex];
            runningSpriteIndex = (runningSpriteIndex + 1) % runningSprites.Length; // 다음 Sprite로 변경

            yield return new WaitForSeconds(0.2f); // 0.2초 대기
        }
    }
}
