using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject configurationPanel; // 조작할 환경설정 패널
    public float slideDuration = 0.5f; // 패널 이동 애니메이션 지속 시간

    private bool isPanelVisible = false;

    public void TogglePanel()
    {
        if (isPanelVisible)
        {
            StartCoroutine(SlideOut());
        }
        else
        {
            StartCoroutine(SlideIn());
        }
    }

    // 패널 등장 코루틴
    private IEnumerator SlideIn()
    {
        RectTransform panelRect = configurationPanel.GetComponent<RectTransform>();
        Vector2 startPos = new Vector2(-panelRect.rect.width, panelRect.anchoredPosition.y);
        Vector2 endPos = new Vector2(0, panelRect.anchoredPosition.y);

        panelRect.anchoredPosition = startPos;

        float elapsedTime = 0f;
        while (elapsedTime < slideDuration)
        {
            panelRect.anchoredPosition = Vector2.Lerp(startPos, endPos, (elapsedTime / slideDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panelRect.anchoredPosition = endPos; // 종료 위치로 왔는지 확인 절차
        isPanelVisible = true;
    }

    // 패널 가리기 코루틴
    private IEnumerator SlideOut()
    {
        RectTransform panelRect = configurationPanel.GetComponent<RectTransform>();
        Vector2 startPos = panelRect.anchoredPosition;
        Vector2 endPos = new Vector2(-panelRect.rect.width, panelRect.anchoredPosition.y);

        float elapsedTime = 0f;
        while (elapsedTime < slideDuration)
        {
            panelRect.anchoredPosition = Vector2.Lerp(startPos, endPos, (elapsedTime / slideDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panelRect.anchoredPosition = endPos; // 종료 위치로 왔는지 확인 절차
        isPanelVisible = false;
    }
}