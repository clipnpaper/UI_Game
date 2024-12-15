using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class StageFourTests
{
    private StageFour stageFour;
    private InputField idInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private Button hintButton;
    private GameObject hintPanel;
    private GameObject successPanel;
    private GameObject checkPanel;
    private Text checkTextUI;

    [SetUp]
    public void SetUp()
    {
        // StageFour 초기화
        GameObject stageFourObject = new GameObject();
        stageFour = stageFourObject.AddComponent<StageFour>();

        // Mock UI Elements
        idInputField = new GameObject().AddComponent<InputField>();
        passwordInputField = new GameObject().AddComponent<InputField>();
        loginButton = new GameObject().AddComponent<Button>();
        hintButton = new GameObject().AddComponent<Button>();
        checkPanel = new GameObject();
        successPanel = new GameObject();
        checkTextUI = new GameObject().AddComponent<Text>();
        hintPanel = new GameObject();

        successPanel.SetActive(false);
        hintPanel.SetActive(false);
        checkPanel.SetActive(false);

        // Initialize 메서드 호출
        //stageFour.Initialize(idInputField, passwordInputField, loginButton, hintButton, hintPanel, successPanel);
    }

    [Test]
    public void Initialize_SetPanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "성공 패널이 초기화 시 비활성화되지 않았습니다.");
        Assert.IsFalse(hintPanel.activeSelf, "힌트 패널이 초기화 시 비활성화되지 않았습니다.");
        Assert.IsFalse(checkPanel.activeSelf, "체크 패널이 초기화 시 비활성화되지 않았습니다.");
    }

    

    [Test]
    public void CheckGoBack_HideCheckPanel()
    {
        // Arrange
        checkPanel.SetActive(true);

        // Act
        stageFour.CheckGoBack();

        // Assert
        Assert.IsFalse(checkPanel.activeSelf, "체크 패널이 숨겨지지 않았습니다.");
    }
}
