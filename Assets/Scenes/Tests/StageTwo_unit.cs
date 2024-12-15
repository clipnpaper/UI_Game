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
        // StageTwo �ʱ�ȭ
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

        // Initialize �޼��� ȣ��
        stageTwo.Initialize(idInputField, passwordInputField, loginButton, hintButton, hintPanel, successPanel);
    }

    [Test]
    public void Initialize_SetPanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "���� �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
        Assert.IsFalse(hintPanel.activeSelf, "��Ʈ �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
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
        stageTwo.CheckLogin();

        // Assert
        Assert.IsFalse(successPanel.activeSelf, "�߸��� �ڰ� �������� ���� �г��� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

}
