using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stage5 : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Button hintButton;
    public GameObject hintPanel; // Panel(힌트)
    public GameObject successPanel; // Panel(성공)
    public RectTransform marioTransform; // 마리오 UI 이미지의 RectTransform
    public RectTransform loginButtonTransform; // 로그인 버튼의 RectTransform

    private string correctId = "admin";
    private string correctPassword = "1234";

    public void Initialize(InputField idField, InputField pwField, Button hintBtn, GameObject hint, GameObject success, RectTransform mario, RectTransform loginButton)
    {
        idInputField = idField;
        passwordInputField = pwField;
        hintButton = hintBtn;
        hintPanel = hint;
        successPanel = success;
        marioTransform = mario;
        loginButtonTransform = loginButton;

        // 초기 설정
        successPanel.SetActive(false); // Panel(성공) 숨기기
        hintPanel.SetActive(false); // Panel(힌트) 숨기기
    }

    protected void Start()
    {
        // Panel 초기 상태 설정
        hintPanel.SetActive(false);
        successPanel.SetActive(false);

        // 입력 필드 기본 동작 제거
        idInputField.lineType = InputField.LineType.SingleLine;
        passwordInputField.lineType = InputField.LineType.SingleLine;
    }

    protected void Update()
    {
        GetKey();

        // 마리오와 로그인 버튼의 충돌 감지
        if (IsMarioCollidingWithButton())
        {
            HandleLogin();
        }
    }

    protected void GetKey()
    {
        // Tab 키 인식, 필드 간 전환
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (idInputField.isFocused)
            {
                SetFocus(passwordInputField, false);
            }
            else if (passwordInputField.isFocused)
            {
                SetFocus(idInputField, false);
            }
        }
    }

    protected void SetFocus(InputField field, bool reselectText = true)
    {
        field.ActivateInputField();
        if (reselectText) //필드 간 전환시에 Re-selection 방지
        {
            field.Select();
        }
    }

    private bool IsMarioCollidingWithButton()
    {
        // RectTransform의 영역 겹침 여부를 확인
        return RectTransformUtility.RectangleContainsScreenPoint(loginButtonTransform, marioTransform.position, null);
    }

    private void HandleLogin()
    {
        string enteredId = idInputField.text;
        string enteredPassword = passwordInputField.text;

        if (enteredId == correctId && enteredPassword == correctPassword)
        {
            successPanel.SetActive(true); // 성공 패널 표시
            hintPanel.SetActive(false);  // 힌트 패널 숨기기
        }
        else
        {
            successPanel.SetActive(false); // 성공 패널 숨기기
            hintPanel.SetActive(true);     // 힌트 패널 표시
        }
    }
    
    private void MoveToNextStage()
    {
        MainSystem mainSystem = GetComponent<MainSystem>();
        mainSystem.LoadStageOne();
    }
}
