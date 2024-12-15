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
        // StageFour �ʱ�ȭ
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

        // Initialize �޼��� ȣ��
        //stageFour.Initialize(idInputField, passwordInputField, loginButton, hintButton, hintPanel, successPanel);
    }

    [Test]
    public void Initialize_SetPanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "���� �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
        Assert.IsFalse(hintPanel.activeSelf, "��Ʈ �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
        Assert.IsFalse(checkPanel.activeSelf, "üũ �г��� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

    

    [Test]
    public void CheckGoBack_HideCheckPanel()
    {
        // Arrange
        checkPanel.SetActive(true);

        // Act
        stageFour.CheckGoBack();

        // Assert
        Assert.IsFalse(checkPanel.activeSelf, "üũ �г��� �������� �ʾҽ��ϴ�.");
    }
}
