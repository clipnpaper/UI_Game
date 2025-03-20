using UnityEngine;

public class ScrollButtonControl : MonoBehaviour
{
    public RectTransform scrollButton;  // ScrollButton 물체
    public RectTransform scrollBar; // ScrollBar의 범위를 정의할 RectTransform
    private Vector3 offset;         // 드래그 시, 버튼의 오프셋 저장
    private float minY, maxY;
    public float low_length;
    public float high_length;
    void Start()
    {
        // ScrollBar의 y축 범위 설정
        minY = scrollBar.rect.y - low_length;
        maxY = scrollBar.rect.y + high_length;

        // 초기 위치 설정 (y축 기준으로만 제한)
        scrollButton.position = new Vector3(scrollButton.position.x, Mathf.Clamp(scrollButton.position.y, minY, maxY), scrollButton.position.z);
    }

    void OnMouseDown()
    {
        // 마우스를 클릭할 때, 버튼의 위치와 마우스의 상대적인 위치를 기록
        offset = scrollButton.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag()
    {
        // 마우스를 드래그할 때
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;

        // y축만 변경하고, x축은 그대로 유지하며 이동
        newPosition.x = scrollButton.position.x;

        // y축 범위 제한
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        scrollButton.position = newPosition;
    }
}


