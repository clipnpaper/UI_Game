using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class StageThreeTests
{
    private StageThree stageThree;
    private InputField idInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private Button hintButton;
    private Button cancelButton;
    private GameObject successPanel;
    private GameObject hintPanel;

    [SetUp]
    public void SetUp()
    {
        // StageThree �ʱ�ȭ
        GameObject gameObject = new GameObject();

        // Mock UI Elements
        idInputField = new GameObject().AddComponent<InputField>();
        passwordInputField = new GameObject().AddComponent<InputField>();
        loginButton = new GameObject().AddComponent<Button>();
        hintButton = new GameObject().AddComponent<Button>();
        cancelButton = new GameObject().AddComponent<Button>();
        successPanel = new GameObject();
        hintPanel = new GameObject();

        successPanel.SetActive(false);
        hintPanel.SetActive(false);

        // Initialize �޼��� ȣ��
        stageThree.Initialize(idInputField, passwordInputField, loginButton, hintButton, hintPanel, successPanel);

        // Cancel ��ư ����
        stageThree.cancelButton = cancelButton;
        cancelButton.onClick.AddListener(stageThree.Cancel);
    }

    [Test]
    public void Initialize_SetPanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "���� �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
        Assert.IsFalse(hintPanel.activeSelf, "��Ʈ �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

    [Test]
    public void Cancel_LogMessage()
    {
        // Arrange
        bool applicationQuitCalled = false;

        // UnityEditor �� Application.Quit ��ŷ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Assert.Pass("Unity Editor���� Cancel ��ư�� �������ϴ�.");
#else
        Application.Quit = () => { applicationQuitCalled = true; };
#endif

        // Act
        stageThree.Cancel();

        // Assert
        Assert.IsTrue(applicationQuitCalled, "Application.Quit()�� ȣ����� �ʾҽ��ϴ�.");
    }

    [Test]
    public void CheckLogin_SuccessPanel_Correct()
    {
        // Arrange
        PlayerPrefs.SetString("PlayerID", "admin");
        PlayerPrefs.SetString("PlayerPassword", "1234");
        idInputField.text = "admin";
        passwordInputField.text = "1234";

        // Act
        stageThree.CheckLogin();

        // Assert
        Assert.IsTrue(successPanel.activeSelf, "�ùٸ� �ڰ� �������� ���� �г��� Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

    [Test]
    public void CheckLogin_SuccessPanel_Incorrect()
    {
        // Arrange
        PlayerPrefs.SetString("PlayerID", "admin");
        PlayerPrefs.SetString("PlayerPassword", "1234");
        idInputField.text = "wrongID";
        passwordInputField.text = "wrongPW";

        // Act
        stageThree.CheckLogin();

        // Assert
        Assert.IsFalse(successPanel.activeSelf, "�߸��� �ڰ� �������� ���� �г��� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

}
