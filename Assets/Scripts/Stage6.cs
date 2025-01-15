using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stage6 : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Button hintButton;
    public GameObject hintPanel; // Panel(힌트)
    public GameObject successPanel; // Panel(성공)
    public RectTransform marioTransform; // 마리오 UI 이미지의 RectTransform
    public RectTransform loginButtonTransform; // 로그인 버튼의 RectTransform

    public GameObject speechBubble; // 말풍선 오브젝트
    public Text speechText;         // 말풍선 텍스트
    public string[] messages;       // 대사 목록
    public float typingSpeed = 0.05f; // 타이핑 속도

    private string correctId = "admin";
    private string correctPassword = "1234";

    private int currentMessageIndex = 0; // 현재 출력 중인 대사 인덱스
    private bool isTyping = false; // 대화 중 상태 플래그
    
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
        speechBubble.SetActive(false); // 초기에는 말풍선 숨기기
    }

    protected void Start()
    {
        hintPanel.SetActive(false);
        successPanel.SetActive(false);
        speechBubble.SetActive(false);
        loginButton.gameObject.SetActive(false);
        
        idInputField.lineType = InputField.LineType.SingleLine;
        passwordInputField.lineType = InputField.LineType.SingleLine;
    }

    protected void Update()
    {
        GetKey();
    }

    protected void GetKey()
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
    }

    protected void SetFocus(InputField field, bool reselectText = true)
    {
        field.ActivateInputField();
        if (reselectText)
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

    public void OnMarioClicked()
    {
        if (isTyping) return; // 대화 중이면 리턴하여 중단
        
        if (!speechBubble.activeSelf)
        {
            speechBubble.SetActive(true);
            StartCoroutine(TypeMessage(messages[currentMessageIndex]));
        }
        else
        {
            StopAllCoroutines();
            currentMessageIndex = (currentMessageIndex + 1) % messages.Length;
            StartCoroutine(TypeMessage(messages[currentMessageIndex]));
            // 대화 인덱스가 9를 초과하면 버튼 활성화
            if (currentMessageIndex > 9)
            {
                loginButton.gameObject.SetActive(true); // 버튼 보이기
            }
        }
    }

    private IEnumerator TypeMessage(string message)
    {
        isTyping = true; // 애니메이션 시작
        speechText.text = "";
        foreach (char letter in message)
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(2f);
        isTyping = false; // 애니메이션 종료
    }

    private void MoveToNextStage()
    {
        MainSystem mainSystem = GetComponent<MainSystem>();
        mainSystem.LoadStageOne();
    }
}

