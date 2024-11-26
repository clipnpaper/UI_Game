using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StageThree : MonoBehaviour
{
    [SerializeField] public Button cancelButton;
    
    private InputField idInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private Button nextStageButton;
    private GameObject hintPanel; // Panel(힌트)
    private GameObject successPanel; // Panel(성공)
    
    private string correctId = "admin";
    private string correctPassword = "1234";
    
    public void Initialize(InputField idField, InputField pwField, Button loginBt, Button nextBt, GameObject hint, GameObject success)
    {
        idInputField = idField;
        passwordInputField = pwField;
        loginButton = loginBt;
        nextStageButton = nextBt;
        hintPanel = hint;
        successPanel = success;

        // 초기 설정
        successPanel.SetActive(false); // Panel(성공) 숨기기
        hintPanel.SetActive(false); // Panel(힌트) 숨기기
        loginButton.onClick.AddListener(CheckLogin);
    }

    private void Start()
    {
        // Cancel 버튼 이벤트 추가
        cancelButton.onClick.AddListener(() =>
        {
            if (idInputField == null || passwordInputField == null)
            {
                Debug.LogError("ID 또는 PW 입력 필드가 초기화되지 않았습니다. Initialize 호출을 확인하세요.");
            }
            else
            {
                CancelIDPW();
            }
        });
    }

    public void CancelIDPW()
    {
        // ID와 PW 입력 필드가 null이 아닌지 확인
        if (idInputField == null || passwordInputField == null)
        {
            Debug.LogError("ID 또는 PW 입력 필드가 null입니다. Inspector에서 연결 상태를 확인하세요.");
            return;
        }

        // ID와 PW 입력 필드 초기화
        idInputField.text = string.Empty; // ID 필드 내용을 빈칸으로 설정
        passwordInputField.text = string.Empty; // PW 필드 내용을 빈칸으로 설정

        Debug.Log("ID와 PW 입력 필드가 초기화되었습니다."); // 디버그 메시지 출력
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
        /*
        if (Input.GetKeyDown(KeyCode.Return) && EventSystem.current.currentSelectedGameObject == passwordInputField.gameObject)
        {
            CheckLogin();
        }
        */
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
