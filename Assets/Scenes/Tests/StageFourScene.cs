using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageFourScene
{
    private GameObject usernameInputField;
    private GameObject passwordInputField;
    private GameObject loginButton;



    [SetUp]
    public void Setup()
    {
        // StageOneScene�� �ε��մϴ�.
        SceneManager.LoadScene("StageFourScene");
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator Login_Input_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageFourScene");

        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (�α���)");

        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();


        // UI ��� Ȯ��


        Assert.IsNotNull(usernameInputField, "Username Input Field�� �������� �ʽ��ϴ�.");
        Assert.IsNotNull(passwordInputField, "Password Input Field�� �������� �ʽ��ϴ�.");
        Assert.IsNotNull(loginButton, "Login Button�� �������� �ʽ��ϴ�.");



        // 3. InputField�� �ؽ�Ʈ �Է�


        var usernameField = usernameInputField.GetComponent<InputField>();
        var passwordField = passwordInputField.GetComponent<InputField>();

        usernameField.text = "admin";
        passwordField.text = "1234";

        // �ؽ�Ʈ �Է��� ����� �Ǿ����� Ȯ��
        Assert.AreEqual("admin", usernameField.text, "Username �Է��� �߸��Ǿ����ϴ�.");
        Assert.AreEqual("1234", passwordField.text, "Password �Է��� �߸��Ǿ����ϴ�.");

        loginButton.GetComponent<Button>().onClick.Invoke();

        yield return new WaitForSeconds(1);

    }
}