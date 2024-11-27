using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSystem : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public Button loginButton;
    //public Button nextStageButton;
    public GameObject hintPanel; // Panel(힌트)
    public GameObject successPanel; // Panel(성공)
    public Slider musicSlider; // Slider 추가
    
    protected void Start()
    {
        // 테스트용, 레벨 1 호출
        GameManager.Instance.OnLevelStart(1);


        // 로그인 버튼에 클릭 이벤트 추가
        // loginButton.onClick.AddListener(CheckLogin);

        // 입력 필드 기본 동작 제거
        idInputField.lineType = InputField.LineType.SingleLine;
        passwordInputField.lineType = InputField.LineType.SingleLine;

        // Panel 초기 상태 설정
        //hintPanel.SetActive(false);
        //successPanel.SetActive(false);

        // StageOne 실행 및 패널 전달
        StageOne stageOne = gameObject.AddComponent<StageOne>();
        stageOne.Initialize(idInputField, passwordInputField, loginButton, hintPanel, successPanel);
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
        // Enter 키 인식, pw 필드에서 로그인 시도
        /* if (Input.GetKeyDown(KeyCode.Return) && EventSystem.current.currentSelectedGameObject == passwordInputField.gameObject)
        {
            CheckLogin();
        } */
    }

    protected void SetFocus(InputField field, bool reselectText = true)
    {
        field.ActivateInputField();
        if (reselectText) //필드 간 전환시에 Re-selection 방지
        {
            field.Select();
        }
    }
    /*
    protected void CheckLogin()
    {
        string enteredId = idInputField.text;
        string enteredPassword = passwordInputField.text;

        // ID와 PW가 일치하면 성공 메시지 표시
        if (enteredId == correctId && enteredPassword == correctPassword)
        {
            successMessage.text = "스테이지 성공!";
        }
        else
        {
            successMessage.text = "로그인 실패, 다시 시도하세요.";
        }
    }
    */
    /*public void LoadStageTwo()
    {
        Destroy(GetComponent<StageOne>());
        StageTwo stageTwo = gameObject.AddComponent<StageTwo>();
        stageTwo.Initialize(idInputField, passwordInputField, loginButton, hintPanel, successPanel);
    }*/
    
    public void LoadStageTwo()
    {
        GameManager.Instance.OnLevelStart(2);
        SceneManager.LoadScene("StageTwoScene");
        Destroy(GetComponent<StageOne>());
        StageTwo stageTwo = gameObject.AddComponent<StageTwo>();
        stageTwo.Initialize(idInputField, passwordInputField, loginButton, hintPanel, successPanel);
    }
    public void LoadStageThree()
    {
        GameManager.Instance.OnLevelStart(3);
        SceneManager.LoadScene("StageThreeScene");
        Destroy(GetComponent<StageTwo>());
        StageThree stageThree = gameObject.AddComponent<StageThree>();
        stageThree.Initialize(idInputField, passwordInputField, loginButton, hintPanel, successPanel);
    }
}