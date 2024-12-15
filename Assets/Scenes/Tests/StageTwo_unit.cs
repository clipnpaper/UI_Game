using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class StageTwoTests
{
    private StageTwo stageTwo;
    private InputField idInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private Button hintButton;
    private GameObject hintPanel;
    private GameObject successPanel;

    [SetUp]
    public void SetUp()
    {
        // StageTwo 초기화
        GameObject stageTwoObject = new GameObject();
        stageTwo = stageTwoObject.AddComponent<StageTwo>();

        // Mock UI Elements
        idInputField = new GameObject().AddComponent<InputField>();
        passwordInputField = new GameObject().AddComponent<InputField>();
        loginButton = new GameObject().AddComponent<Button>();
        hintButton = new GameObject().AddComponent<Button>();
        hintPanel = new GameObject();
        successPanel = new GameObject();

        successPanel.SetActive(false);
        hintPanel.SetActive(false);

        // Initialize 메서드 호출
        stageTwo.Initialize(idInputField, passwordInputField, loginButton, hintButton, hintPanel, successPanel);
    }

    [Test]
    public void Initialize_SetPanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "성공 패널이 초기화 시 비활성화되지 않았습니다.");
        Assert.IsFalse(hintPanel.activeSelf, "힌트 패널이 초기화 시 비활성화되지 않았습니다.");
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
        stageTwo.CheckLogin();

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
        stageTwo.CheckLogin();

        // Assert
        Assert.IsFalse(successPanel.activeSelf, "잘못된 자격 증명으로 성공 패널이 비활성화되지 않았습니다.");
    }

}
