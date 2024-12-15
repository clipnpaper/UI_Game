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
        // StageOneScene을 로드합니다.
        SceneManager.LoadScene("StageFourScene");
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator Login_Input_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageFourScene");

        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (로그인)");

        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();


        // UI 요소 확인


        Assert.IsNotNull(usernameInputField, "Username Input Field가 존재하지 않습니다.");
        Assert.IsNotNull(passwordInputField, "Password Input Field가 존재하지 않습니다.");
        Assert.IsNotNull(loginButton, "Login Button이 존재하지 않습니다.");



        // 3. InputField에 텍스트 입력


        var usernameField = usernameInputField.GetComponent<InputField>();
        var passwordField = passwordInputField.GetComponent<InputField>();

        usernameField.text = "admin";
        passwordField.text = "1234";

        // 텍스트 입력이 제대로 되었는지 확인
        Assert.AreEqual("admin", usernameField.text, "Username 입력이 잘못되었습니다.");
        Assert.AreEqual("1234", passwordField.text, "Password 입력이 잘못되었습니다.");

        loginButton.GetComponent<Button>().onClick.Invoke();

        yield return new WaitForSeconds(1);

    }
}