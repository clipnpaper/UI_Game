using UnityEngine;

public class SlideOutMenu : MonoBehaviour
{
    public RectTransform menuSquare; // 숨겨진 메뉴 (menu_square)
    public RectTransform menuButton;
    public float slideSpeed = 5f; // 슬라이드 속도
    private bool isMenuVisible = false; // 메뉴가 보이는지 여부
    private Vector3 hideScale;
    private Vector3 showScale;
    void Start()
    {
        // 초기 scale을 x = 0으로 설정
        
        Vector3 initialScale = menuSquare.localScale;
        showScale = initialScale;
        initialScale= menuButton.localScale;
        initialScale.x = 0f; // x축을 0으로 설정
        hideScale = initialScale;
        menuSquare.localScale = hideScale;
    }

    // 메뉴 버튼 클릭 시 메뉴 상태를 전환
    public void OnClick()
    {
        isMenuVisible = !isMenuVisible; // 메뉴 보이기/숨기기 전환
        // 여기서 버튼 클릭 시 실행할 코드 작성
        Debug.Log("Square clicked!");
    }

    void Update()
    {
        // 메뉴가 보이도록 슬라이드
        if (isMenuVisible)
        {
            // x축 크기를 1로 증가시키기
            menuSquare.localScale = Vector3.Lerp(menuSquare.localScale, new Vector3(1f, showScale.y, showScale.z), Time.deltaTime * slideSpeed);
        }
        else
        {
            // x축 크기를 0으로 줄이기
            menuSquare.localScale = Vector3.Lerp(menuSquare.localScale, new Vector3(0f, hideScale.y, hideScale.z), Time.deltaTime * slideSpeed);
        }
    }
}