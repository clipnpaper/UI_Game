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
        // StageOneScene�� �ε��մϴ�.
        SceneManager.LoadScene("StageTwoScene");
    }
    [UnityTest]
    public IEnumerator Login_Input_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageTwoScene");

        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (�α���)");
        settingsButton = GameObject.Find("Button (ȯ�漳��)"); // ���� ��ư
        settingsUI = GameObject.Find("Panel (ȯ�漳��)");         // ���� ȭ��
        bgmSlider = GameObject.Find("MusicSlider"); // ����� �����̴�
        sfxSlider = GameObject.Find("SFXSlider"); // ȿ���� �����̴�
        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();


        // UI ��� Ȯ��
        Assert.IsNotNull(settingsButton, "Settings Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(settingsUI, "Settings UI�� ã�� �� �����ϴ�.");

        Assert.IsNotNull(usernameInputField, "Username Input Field�� �������� �ʽ��ϴ�.");
        Assert.IsNotNull(passwordInputField, "Password Input Field�� �������� �ʽ��ϴ�.");
        Assert.IsNotNull(loginButton, "Login Button�� �������� �ʽ��ϴ�.");
        Assert.IsNotNull(bgmSlider, "BGM Slider�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(sfxSlider, "SFX Slider�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(bgmAudioSource, "BGM AudioSource�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(sfxAudioSource, "SFX AudioSource�� ã�� �� �����ϴ�.");


        settingsButton.GetComponent<Button>().onClick.Invoke();

        var bgmSliderComponent = bgmSlider.GetComponent<Slider>();
        var sfxSliderComponent = sfxSlider.GetComponent<Slider>();

        // �����̴� ���� ����
        bgmSliderComponent.value = 0.0f; // 50%�� ����
        bgmSliderComponent.value = 1.0f; // 50%�� ����

        settingsButton.GetComponent<Button>().onClick.Invoke();
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
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    
}
