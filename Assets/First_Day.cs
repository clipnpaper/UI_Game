using UnityEngine;
using UnityEngine.UI;

public class LoginSystem : MonoBehaviour
{
    public InputField idInputField;
    public InputField pwInputField;
    public Text successMessage;
    public Button loginButton;

    // ������ ID�� PW (�� �κ��� ���� ������Ʈ������ ������ ����ϴ� �κ����� ��ü�ؾ� ��)
    private string correctID = "admin";
    private string correctPW = "1234";

    void Start()
    {
        // ���� �޽����� ó������ �� ���·� ����
        successMessage.text = "";

        // �α��� ��ư�� Ŭ�� �̺�Ʈ �߰�
        loginButton.onClick.AddListener(CheckLogin);
    }

    void CheckLogin()
    {
        string enteredID = idInputField.text;
        string enteredPW = pwInputField.text;

        // ID�� PW�� ��ġ�ϸ� ���� �޽��� ǥ��
        if (enteredID == correctID && enteredPW == correctPW)
        {
            successMessage.text = "�������� ����!";
        }
        else
        {
            successMessage.text = "�α��� ����, �ٽ� �õ��ϼ���.";
        }
    }
}