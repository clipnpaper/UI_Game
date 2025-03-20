using UnityEngine;

public class SlideOutMenu : MonoBehaviour
{
    public RectTransform menuSquare; // 숨겨진 메뉴 (menu_square)
    public RectTransform menuButton;
    private bool isMenuVisible = false; // 메뉴가 보이는지 여부
    public Animator SlideAnimator;
    
    void Start()
    {
        SlideAnimator.SetInteger("State", 0);
    }

    // 메뉴 버튼 클릭 시 메뉴 상태를 전환
    public void OnClick()
    {
        SlideAnimator.SetInteger("State", 1 - SlideAnimator.GetInteger("State"));// 메뉴 보이기/숨기기 전환
        // 여기서 버튼 클릭 시 실행할 코드 작성
        Debug.Log("Square clicked!");
    }

    void Update()
    {
       
    }
}