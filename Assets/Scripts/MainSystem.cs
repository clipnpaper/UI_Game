using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainSystem : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public Text successMessage;
    public Button loginButton;

    // 정해진 ID와 PW (이 부분은 실제 프로젝트에서는 서버와 통신하는 부분으로 대체해야 함)
    protected string correctId = "admin";
    protected string correctPassword = "1234";

    protected virtual void Start()
    {
        // 성공 메시지를 처음에는 빈 상태로 설정
        successMessage.text = "";

        // 로그인 버튼에 클릭 이벤트 추가
        loginButton.onClick.AddListener(CheckLogin);

        // 입력 필드 기본 동작 제거
        idInputField.lineType = InputField.LineType.SingleLine;
        pwInputField.lineType = InputField.LineType.SingleLine;
    }

    protected virtual void Update()
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
                SetFocus(pwInputField, false);
            } else if (pwInputField.isFocused)
            {
                SetFocus(idInputField, false);
            }
        }
        // Enter 키 인식, pw 필드에서 로그인 시도
        if (Input.GetKeyDown(KeyCode.Return) && EventSystem.current.currentSelectedGameObject == pwInputField.gameObject)
        {
            CheckLogin();
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

    protected virtual void CheckLogin()
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
}