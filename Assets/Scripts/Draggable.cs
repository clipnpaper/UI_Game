using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Canvas canvas; // 부모 Canvas
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 필요한 초기화 코드 추가 (현재는 빈 상태)
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            Vector2 localPointerPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out localPointerPosition);

            rectTransform.anchoredPosition = localPointerPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 놓은 자리 그대로 유지하므로 별도의 추가 처리가 필요 없습니다.
        // 단, 드래그를 멈췄을 때의 위치를 확정 지어주는 로그나 추가 액션을 원할 경우 아래 코드를 추가하세요.
        Debug.Log("드래그 종료. 최종 위치: " + rectTransform.anchoredPosition);
    }
}