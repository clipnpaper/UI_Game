using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class StageTwoScene
{
    private GameObject usernameInputField;
    private GameObject passwordInputField;
    private GameObject loginButton;

    private GameObject settingsButton;
    private GameObject settingsUI;

    private GameObject bgmSlider;
    private GameObject sfxSlider;

    // A Test behaves as an ordinary method

    [SetUp]
    public void Setup()
    {
        // StageOneScene을 로드합니다.
        SceneManager.LoadScene("StageTwoScene");
    }
    [UnityTest]
    public IEnumerator Login_Input_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageTwoScene");

        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (로그인)");
        settingsButton = GameObject.Find("Button (환경설정)"); // 설정 버튼
        settingsUI = GameObject.Find("Panel (환경설정)");         // 설정 화면
        bgmSlider = GameObject.Find("MusicSlider"); // 배경음 슬라이더
        sfxSlider = GameObject.Find("SFXSlider"); // 효과음 슬라이더
        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();


        // UI 요소 확인
        Assert.IsNotNull(settingsButton, "Settings Button을 찾을 수 없습니다.");
        Assert.IsNotNull(settingsUI, "Settings UI를 찾을 수 없습니다.");

        Assert.IsNotNull(usernameInputField, "Username Input Field가 존재하지 않습니다.");
        Assert.IsNotNull(passwordInputField, "Password Input Field가 존재하지 않습니다.");
        Assert.IsNotNull(loginButton, "Login Button이 존재하지 않습니다.");
        Assert.IsNotNull(bgmSlider, "BGM Slider를 찾을 수 없습니다.");
        Assert.IsNotNull(sfxSlider, "SFX Slider를 찾을 수 없습니다.");
        Assert.IsNotNull(bgmAudioSource, "BGM AudioSource를 찾을 수 없습니다.");
        Assert.IsNotNull(sfxAudioSource, "SFX AudioSource를 찾을 수 없습니다.");


        settingsButton.GetComponent<Button>().onClick.Invoke();

        var bgmSliderComponent = bgmSlider.GetComponent<Slider>();
        var sfxSliderComponent = sfxSlider.GetComponent<Slider>();

        // 슬라이더 값을 변경
        bgmSliderComponent.value = 0.0f; // 50%로 설정
        bgmSliderComponent.value = 1.0f; // 50%로 설정

        settingsButton.GetComponent<Button>().onClick.Invoke();
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
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    
}
