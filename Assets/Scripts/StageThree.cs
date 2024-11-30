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
    private Button hintButton;
    //private Button nextStageButton;
    private GameObject hintPanel; // Panel(힌트)
    private GameObject successPanel; // Panel(성공)
    
    private string correctId = "admin";
    private string correctPassword = "1234";
    
    public void Initialize(InputField idField, InputField pwField, Button loginBt, Button hintBtn, GameObject hint, GameObject success)
    {
        idInputField = idField;
        passwordInputField = pwField;
        loginButton = loginBt;
        hintButton = hintBtn;
        //nextStageButton = nextBt;
        hintPanel = hint;
        successPanel = success;

        // 초기 설정
        successPanel.SetActive(false); // Panel(성공) 숨기기
        hintPanel.SetActive(false); // Panel(힌트) 숨기기
        loginButton.onClick.AddListener(CheckLogin);
    }

    void Start()
    {
        // Cancel 버튼 이벤트 추가
        /*cancelButton.onClick.AddListener(() =>
        {
            Cancel();
        });*/

        // 초기화 작업
        Debug.Log("StageThree initialized.");
        HintManager hintManager = FindObjectOfType<HintManager>();
        if (hintManager != null)
        {
            hintManager.LoadHintForLevel(3);
            Debug.Log("Hint for level 3 loaded.");
        }
        else
        {
            Debug.LogError("HintManager not found.");
        }
    }

    public void Cancel()
    {
        Debug.Log("게임 종료 버튼이 눌렸습니다."); // Unity Editor에서 로그 확인용
        
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Unity Editor에서 Play 모드 종료
    #else
        Application.Quit(); // 빌드된 게임에서 애플리케이션 종료
    #endif
    }

    private void Update()
    {
        //GetKey();
    }

    /*
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
        
    }

    private void SetFocus(InputField field, bool reselectText = true)
    {
        field.ActivateInputField();
        if (reselectText)
        {
            field.Select();
        }
    }
    */

    private void ShowHint()
    {
        hintPanel.SetActive(true); // 힌트 패널 표시
    }

    private void CheckLogin()
    {
        string enteredId = idInputField.text;
        string enteredPassword = passwordInputField.text;

        if (enteredId == correctId && enteredPassword == correctPassword)
        {
            successPanel.SetActive(true); // 성공 패널 표시
            //hintPanel.SetActive(false); // 힌트 패널 숨기기
        }
        else
        {
            successPanel.SetActive(false); // 성공 패널 숨기기
            //hintPanel.SetActive(true); // 힌트 패널 표시
        }
    }
}
