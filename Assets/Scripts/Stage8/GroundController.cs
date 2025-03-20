using UnityEngine;

public class GroundController : MonoBehaviour
{
    public float expansionSpeed = 1f;  // 늘어나는 속도
    private bool isClicked = false;    // 클릭 여부

    public BoxCollider2D col;        // BoxCollider2D 컴포넌트

    void Start()
    {
        // Rigidbody2D와 BoxCollider2D 컴포넌트를 가져옵니다.
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // 마우스 클릭으로 아이템을 확장하도록 설정
        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            if (col.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                OnClick(); // 클릭한 바닥만 확장
            }
        }

        if (isClicked)
        {
            // 클릭된 상태에서 오른쪽으로 늘어나도록 크기 변경
            Vector3 newSize = transform.localScale;
            newSize.x += expansionSpeed * Time.deltaTime; // X 크기만 늘림
            if (newSize.x > 10f) // 예시로 10 이상으로 크기가 늘어나지 않게
            {
                newSize.x = 10f;
            }
            transform.localScale = newSize;
        }
    }

    // 클릭 시 호출되는 함수
    private void OnClick()
    {
        isClicked = true; // 클릭 시 상태 토글
    }
}