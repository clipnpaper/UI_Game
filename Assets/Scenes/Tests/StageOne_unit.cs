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
        // StageOne 초기화
        GameObject stageOneObject = new GameObject();

        // Mock InputField 설정
        idInputField = new GameObject().AddComponent<InputField>();
        passwordInputField = new GameObject().AddComponent<InputField>();

        // Mock Success Panel 설정
        successPanel = new GameObject();
        successPanel.SetActive(false);

        // StageOne 초기화 메서드 호출
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
        Assert.AreEqual("admin", PlayerPrefs.GetString("TestUser"), "ID가 저장되지 않았습니다.");
        Assert.AreEqual("1234", PlayerPrefs.GetString("PlayerPassword"), "Password가 저장되지 않았습니다.");
        Assert.IsTrue(successPanel.activeSelf, "Success Panel이 활성화되지 않았습니다.");
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
        Assert.IsFalse(successPanel.activeSelf, "Success Panel이 활성화되었습니다.");
    }


    [Test]
    public void Initialize_PanelsInactive()
    {
        // Assert
        Assert.IsFalse(successPanel.activeSelf, "Success Panel이 초기화 시 비활성화되지 않았습니다.");
    }

    private GameObject hintPanel;
    private Button hintButton;

    [SetUp]
    public void SetUpHint()
    {
        hintPanel = new GameObject();
        hintPanel.SetActive(false);

        hintButton = new GameObject().AddComponent<Button>();
        

        // Hint 버튼 클릭 이벤트 설정
        hintButton.onClick.AddListener(() => hintPanel.SetActive(true));
    }

    [Test]
    public void HintButton_ActivateHintPanel()
    {
        // Arrange
        Assert.IsFalse(hintPanel.activeSelf, "Hint Panel이 초기 상태에서 활성화되었습니다.");

        // Act
        hintButton.onClick.Invoke();

        // Assert
        Assert.IsTrue(hintPanel.activeSelf, "Hint Panel이 버튼 클릭 후 활성화되지 않았습니다.");
    }



}
