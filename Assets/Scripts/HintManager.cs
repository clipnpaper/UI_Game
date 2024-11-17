using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hintText; // 힌트 텍스트 표시 UI
    [SerializeField] private GameObject hintPanel; // 힌트 패널 오브젝트

    private HintSystem currentHint;

    // 레벨에 맞는 힌트 로드
    public void LoadHintForLevel(int level)
    {
        if (currentHint != null)
        {
            Destroy(currentHint);
        }
        
        switch(level)
        {
            case 1:
                currentHint = gameObject.AddComponent<Level1Hint>();
                break;
            case 2:
                currentHint = gameObject.AddComponent<Level2Hint>();
                break;
            case 3:
                currentHint = gameObject.AddComponent<Level3Hint>();
                break;
            case 4:
                currentHint = gameObject.AddComponent<Level4Hint>();
                break;
            default:
                Debug.LogWarning("No Hint");
                return;
        }

        DisplayHint();
    }

    // 힌트를 화면에 표시
    public void DisplayHint()
    {
        if (currentHint != null && hintText != null)
        {
            hintText.text = currentHint.GetHint();
            if (hintPanel != null)
            {
                hintPanel.SetActive(true); // 패널 활성화
            }
        }
        else
        {
            hintText.text = "No Hint";
        }
    }

    // 버튼 클릭 시 힌트 패널 숨기기
    public void HideHint()
    {
        if (hintPanel != null)
        {
            hintPanel.SetActive(false); // 패널 비활성화
        }
        if (hintText != null)
        {
            hintText.text = ""; // 텍스트 초기화
        }
    }
}