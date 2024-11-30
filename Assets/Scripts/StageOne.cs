using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageOne : MonoBehaviour
{
    private InputField idInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private Button hintButton;
    //private Button nextStageButton;
    private GameObject hintPanel; // Panel(힌트)
    private GameObject successPanel; // Panel(성공)

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
        //nextStageButton.gameObject.SetActive(false); // 다음 스테이지 버튼 숨기기

        loginButton.onClick.AddListener(CheckLogin);
        hintButton.onClick.AddListener(ShowHint);
        //nextStageButton.onClick.AddListener(MoveToNextStage);
    }

    private void Update()
    {
        GetKey();
    }

    private void GetKey()
    {
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
        if (Input.GetKeyDown(KeyCode.Return) && EventSystem.current.currentSelectedGameObject == passwordInputField.gameObject)
        {
            CheckLogin();
        }
    }

    private void SetFocus(InputField field, bool reselectText = true)
    {
        field.ActivateInputField();
        if (reselectText)
        {
            field.Select();
        }
    }

    private void CheckLogin()
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

    private void ShowHint()
    {
        hintPanel.SetActive(true); // 힌트 패널 표시
    }

    private void MoveToNextStage()
    {
        MainSystem mainSystem = GetComponent<MainSystem>();
        mainSystem.LoadStageTwo();
    }
}