using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageTwo : MonoBehaviour
{
    private InputField idInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private GameObject hintPanel; // Panel(힌트)
    private GameObject successPanel; // Panel(성공)

    private string correctId = "admin";
    private string correctPassword = "1234";

    public void Initialize(InputField idField, InputField pwField, Button btn, GameObject hint, GameObject success)
    {
        idInputField = idField;
        passwordInputField = pwField;
        loginButton = btn;
        hintPanel = hint;
        successPanel = success;

        // 초기 설정
        successPanel.SetActive(false); // Panel(성공) 숨기기
        hintPanel.SetActive(false); // Panel(힌트) 숨기기
        loginButton.onClick.AddListener(CheckLogin);
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
            hintPanel.SetActive(false); // 힌트 패널 숨기기
        }
        else
        {
            successPanel.SetActive(false); // 성공 패널 숨기기
            hintPanel.SetActive(true); // 힌트 패널 표시
        }
    }
}
