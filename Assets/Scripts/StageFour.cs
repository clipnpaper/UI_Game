using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class StageFour : MonoBehaviour
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
    
    private string outputIDText = "";
    private string outputPWText = "";
    
    private string[] keyboardRows = new string[]
    {
        "1234567890",
        "qwertyuiop",
        "asdfghjkl",
        "zxcvbnm"
    };
    public void Initialize(InputField idField, InputField pwField, Button loginBt, Button hintBtn, GameObject hint, GameObject success)
    {
        passwordInputField = pwField;
        loginButton = loginBt;
        hintButton = hintBtn;
        //nextStageButton = nextBt;
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
        
        idInputField.onValueChanged.AddListener(HandleInputIDChange);
        passwordInputField.onValueChanged.AddListener(HandleInputPWChange);
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
    private void HandleInputIDChange(string input)
    {
        // 마지막 입력된 문자를 변환
        if (input.Length > 0)
        {
            char lastChar = input[input.Length - 1];
            string transformedChar = TransformChar(lastChar);
            outputIDText += transformedChar;
        }
        else
        {
            outputIDText = "";
        }
    }
    private void HandleInputPWChange(string input)
    {
        // 마지막 입력된 문자를 변환
        if (input.Length > 0)
        {
            char lastChar = input[input.Length - 1];
            string transformedChar = TransformChar(lastChar);
            outputPWText += transformedChar;
        }
        else
        {
            outputPWText = "";
        }
    }
    private string TransformChar(char c)
    {
        // 대소문자 구분
        c = char.ToLower(c);

        foreach (string row in keyboardRows)
        {
            int index = row.IndexOf(c);
            if (index != -1)
            {
                // 오른쪽 문자로 변환, 배열 끝이면 첫 문자로 순환
                int nextIndex = (index + 1) % row.Length;
                return row[nextIndex].ToString();
            }
        }

        return c.ToString(); // 변환 불가능한 경우 그대로 반환
    }
    protected void SetFocus(InputField field, bool reselectText = true)
    {
        field.ActivateInputField();
        if (reselectText) //필드 간 전환시에 Re-selection 방지
        {
            field.Select();
        }
    }
    public void CheckLogin()
    {
        Debug.Log("ResultID : " + outputIDText + "\nResultPW : " + outputPWText);
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
        mainSystem.LoadStageOne();
    }
}