using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageOne : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Button hintButton;
    //private Button nextStageButton;
    public GameObject hintPanel; // Panel(힌트)
    public GameObject successPanel; // Panel(성공)

    private string correctId = "admin";
    private string correctPassword = "1234";

    public void Initialize(InputField idField, InputField pwField, Button btn, Button hintBtn, GameObject hint, GameObject success)
    {
        idInputField = idField;
        passwordInputField = pwField;
        loginButton = btn;
        hintButton = hintBtn;
        //nextStageButton = nextBtn;
        hintPanel = hint;
        successPanel = success;

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
    }

    protected void GetKey()
    {
        // Tab 키 인식, 필드 간 전환
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (idInputField.isFocused)
            {
                SetFocus(passwordInputField, false);
            } else if (passwordInputField.isFocused)
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

    public void Register()
    {
        string enteredId = idInputField.text;
        string enteredPassword = passwordInputField.text;

        if (string.IsNullOrEmpty(enteredId) || string.IsNullOrEmpty(enteredPassword))
        {
            Debug.Log("ID and Password cannot be empty.");
            return;
        }

        PlayerPrefs.SetString("PlayerID", enteredId);
        PlayerPrefs.SetString("PlayerPassword", enteredPassword);
        PlayerPrefs.Save();

        Debug.Log("Registration success");
        successPanel.SetActive(true);
    }
    /*
    public void CheckLogin()
    {
        string enteredId = idInputField.text;
        string enteredPassword = passwordInputField.text;

        if (enteredId == correctId && enteredPassword == correctPassword)
        {
            successPanel.SetActive(true); // 성공 패널 표시
            //nextStageButton.gameObject.SetActive(true); // 다음 스테이지 버튼 표시
            hintPanel.SetActive(false); // 힌트 패널 숨기기
        }
        else
        {
            successPanel.SetActive(false); // 성공 패널 숨기기
            //hintPanel.SetActive(true); // 힌트 패널 표시
        }
    }
    */
    private void MoveToNextStage()
    {
        MainSystem mainSystem = GetComponent<MainSystem>();
        mainSystem.LoadStageTwo();
    }
}