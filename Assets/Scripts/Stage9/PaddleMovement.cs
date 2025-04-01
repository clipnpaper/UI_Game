using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); // 좌우 방향키 입력 받기
        transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime); // 패들 이동
    }
}