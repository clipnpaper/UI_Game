using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageOneTests
{
    private StageOne stageOne;
    private InputField idInputField;
    private InputField passwordInputField;
    private GameObject successPanel;

    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("StageOneScene");
        // StageOne �ʱ�ȭ
        GameObject stageOneObject = new GameObject();

        // Mock InputField ����
        idInputField = new GameObject().AddComponent<InputField>();
        passwordInputField = new GameObject().AddComponent<InputField>();

        // Mock Success Panel ����
        successPanel = new GameObject();
        successPanel.SetActive(false);

        // StageOne �ʱ�ȭ �޼��� ȣ��
        stageOne.Initialize(idInputField, passwordInputField, null, null, null, successPanel);
    }

    [Test]
    public void Register_IDAndPassword()
    {
        //yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");
        // Arrange
        idInputField.text = "admin";
        passwordInputField.text = "1234";

        // Act
        stageOne.Register();

        // Assert
        Assert.AreEqual("admin", PlayerPrefs.GetString("TestUser"), "ID�� ������� �ʾҽ��ϴ�.");
        Assert.AreEqual("1234", PlayerPrefs.GetString("PlayerPassword"), "Password�� ������� �ʾҽ��ϴ�.");
        Assert.IsTrue(successPanel.activeSelf, "Success Panel�� Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

    [Test]
    public void Register_SuccessPanel()
    {
        //yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");
        // Arrange
        idInputField.text = "";
        passwordInputField.text = "";

        // Act
        stageOne.Register();

        // Assert
        Assert.IsFalse(successPanel.activeSelf, "Success Panel�� Ȱ��ȭ�Ǿ����ϴ�.");
    }


    [Test]
    public void Initialize_PanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "Success Panel�� �ʱ�ȭ �� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

    private GameObject hintPanel;
    private Button hintButton;

    [SetUp]
    public void SetUpHint()
    {
        hintPanel = new GameObject();
        hintPanel.SetActive(false);

        hintButton = new GameObject().AddComponent<Button>();
        

        // Hint ��ư Ŭ�� �̺�Ʈ ����
        hintButton.onClick.AddListener(() => hintPanel.SetActive(true));
    }

    [Test]
    public void HintButton_ActivateHintPanel()
    {
        // Arrange
        Assert.IsFalse(hintPanel.activeSelf, "Hint Panel�� �ʱ� ���¿��� Ȱ��ȭ�Ǿ����ϴ�.");

        // Act
        hintButton.onClick.Invoke();

        // Assert
        Assert.IsTrue(hintPanel.activeSelf, "Hint Panel�� ��ư Ŭ�� �� Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }



}
