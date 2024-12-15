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
        // StageThree 초기화
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

        // Initialize 메서드 호출
        stageThree.Initialize(idInputField, passwordInputField, loginButton, hintButton, hintPanel, successPanel);

        // Cancel 버튼 설정
        stageThree.cancelButton = cancelButton;
        cancelButton.onClick.AddListener(stageThree.Cancel);
    }

    [Test]
    public void Initialize_SetPanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "성공 패널이 초기화 시 비활성화되지 않았습니다.");
        Assert.IsFalse(hintPanel.activeSelf, "힌트 패널이 초기화 시 비활성화되지 않았습니다.");
    }

    [Test]
    public void Cancel_LogMessage()
    {
        // Arrange
        bool applicationQuitCalled = false;

        // UnityEditor 및 Application.Quit 모킹
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Assert.Pass("Unity Editor에서 Cancel 버튼을 눌렀습니다.");
#else
        Application.Quit = () => { applicationQuitCalled = true; };
#endif

        // Act
        stageThree.Cancel();

        // Assert
        Assert.IsTrue(applicationQuitCalled, "Application.Quit()이 호출되지 않았습니다.");
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
        Assert.IsTrue(successPanel.activeSelf, "올바른 자격 증명으로 성공 패널이 활성화되지 않았습니다.");
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
        Assert.IsFalse(successPanel.activeSelf, "잘못된 자격 증명으로 성공 패널이 비활성화되지 않았습니다.");
    }

}
