using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StageThree : MonoBehaviour
{
    [SerializeField] public Button cancelButton;
    
    public InputField idInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Button hintButton;
    //private Button nextStageButton;
    public GameObject hintPanel; // Panel(힌트)
    public GameObject successPanel; // Panel(성공)
    
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
    
    public void Cancel()
    {
        Debug.Log("게임 종료 버튼이 눌렸습니다."); // Unity Editor에서 로그 확인용
        
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Unity Editor에서 Play 모드 종료
    #else
        Application.Quit(); // 빌드된 게임에서 애플리케이션 종료
    #endif
    }

    public void CheckLogin()
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
    private void MoveToNextStage()
    {
        MainSystem mainSystem = GetComponent<MainSystem>();
        mainSystem.LoadStageFour();
    }
}
