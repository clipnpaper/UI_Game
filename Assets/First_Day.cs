using UnityEngine;
using UnityEngine.UI;

public class LoginSystem : MonoBehaviour
{
    public InputField idInputField;
    public InputField pwInputField;
    public Text successMessage;
    public Button loginButton;

    // 정해진 ID와 PW (이 부분은 실제 프로젝트에서는 서버와 통신하는 부분으로 대체해야 함)
    private string correctID = "admin";
    private string correctPW = "1234";

    void Start()
    {
        // 성공 메시지를 처음에는 빈 상태로 설정
        successMessage.text = "";

        // 로그인 버튼에 클릭 이벤트 추가
        loginButton.onClick.AddListener(CheckLogin);
    }

    void CheckLogin()
    {
        string enteredID = idInputField.text;
        string enteredPW = pwInputField.text;

        // ID와 PW가 일치하면 성공 메시지 표시
        if (enteredID == correctID && enteredPW == correctPW)
        {
            successMessage.text = "스테이지 성공!";
        }
        else
        {
            successMessage.text = "로그인 실패, 다시 시도하세요.";
        }
    }
}