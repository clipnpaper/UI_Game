using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageOneScene
{
    private GameObject usernameInputField;
    private GameObject passwordInputField;
    private GameObject loginButton;

    private GameObject hintButton;
    private GameObject hintUI;

    private GameObject closeHintButton;

    private GameObject settingsButton;
    private GameObject settingsUI;

    private GameObject bgmSlider;
    private GameObject sfxSlider;

       
[SetUp]
    public void Setup()
    {
        // StageOneScene�� �ε��մϴ�.
        SceneManager.LoadScene("StageOneScene");
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator Mainsystem_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (�α���)");
        settingsButton = GameObject.Find("Button (ȯ�漳��)"); // ���� ��ư
        settingsUI = GameObject.Find("Panel (ȯ�漳��)");         // ���� ȭ��
        bgmSlider = GameObject.Find("MusicSlider"); // ����� �����̴�
        sfxSlider = GameObject.Find("SFXSlider"); // ȿ���� �����̴�
        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();
        //hintButton = GameObject.Find("Button (��Ʈ)");
        //hintUI = GameObject.Find("Panel (��Ʈ)");
        //closeHintButton = GameObject.Find("Button (hintGoBack)"); // ��Ʈ ���� ��ư
        
        //Assert.IsNotNull(hintButton, "Hint Button�� ã�� �� �����ϴ�.");
        //Assert.IsNotNull(closeHintButton, "Close Hint Button�� ã�� �� �����ϴ�.");
        //Assert.IsNotNull(hintUI, "Hint UI�� ã�� �� �����ϴ�.");

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

        // 3. InputField�� �ؽ�Ʈ �Է�
        settingsButton.GetComponent<Button>().onClick.Invoke();

        var bgmSliderComponent = bgmSlider.GetComponent<Slider>();
        var sfxSliderComponent = sfxSlider.GetComponent<Slider>();

        // �����̴� ���� ����
        sfxSliderComponent.value = 0.8f; // 80%�� ����
        // �����̴� ���� ����
        bgmSliderComponent.value = 0.5f; // 50%�� ����
        // ESC Ű �̺�Ʈ Ʈ����
        TriggerKeyPress(KeyCode.Escape);

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

    private void TriggerKeyPress(KeyCode keyCode)
    {
        // KeyDown �̺�Ʈ�� �������� Ʈ����
        var eventSystem = EventSystem.current;
        if (eventSystem != null)
        {
            var inputModule = eventSystem.currentInputModule as StandaloneInputModule;
            if (inputModule != null)
            {
                var fakeEvent = new UnityEngine.Event()
                {
                    type = EventType.KeyDown,
                    keyCode = keyCode,
                };
                Input.simulateMouseWithTouches = true; // Input System ��� �� ȣȯ
            }
        }
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Hint_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        hintButton = GameObject.Find("Button (��Ʈ)");
        hintUI = GameObject.Find("Panel (��Ʈ)");
        closeHintButton = GameObject.Find("Button (hintGoBack)"); // ��Ʈ ���� ��ư

        Assert.IsNotNull(hintButton, "Hint Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(closeHintButton, "Close Hint Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(hintUI, "Hint UI�� ã�� �� �����ϴ�.");

        hintUI.SetActive(false); // �ʱ� ���¿��� ��Ʈ UI�� ��Ȱ��ȭ�Ǿ� �־�� ��
        Assert.IsFalse(hintUI.activeSelf, "�ʱ� ���¿��� Hint UI�� Ȱ��ȭ�Ǿ� �ֽ��ϴ�.");

        hintButton.GetComponent<Button>().onClick.Invoke();

        yield return null; // UI ���°� ������Ʈ�ǵ��� �� ������ ���

        Assert.IsTrue(hintUI.activeSelf, "Hint ��ư Ŭ�� �� Hint UI�� Ȱ��ȭ���� �ʾҽ��ϴ�.");

        // 4. ��Ʈ ���� ��ư Ŭ��
        closeHintButton.GetComponent<Button>().onClick.Invoke();

        yield return null; // UI ���� ������Ʈ ���
        Assert.IsFalse(hintUI.activeSelf, "Close Hint ��ư Ŭ�� �� Hint UI�� ��Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }
    /*
    [UnityTest]
    public IEnumerator SettingsButton_And_EscKey_Test()
    {
        // 1. �� �ε� �Ϸ� ���
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        // 2. UI ��� ã��
        settingsButton = GameObject.Find("Button (ȯ�漳��)"); // ���� ��ư
        settingsUI = GameObject.Find("Panel (ȯ�漳��)");         // ���� ȭ��


        // UI ��� Ȯ��
        Assert.IsNotNull(settingsButton, "Settings Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(settingsUI, "Settings UI�� ã�� �� �����ϴ�.");

        // 3. �ʱ� ����: ���� ȭ���� ��Ȱ��ȭ�Ǿ� �־�� ��
        settingsUI.SetActive(false); // �ʱ� ���� ����
        Assert.IsFalse(settingsUI.activeSelf, "�ʱ� ���¿��� Settings UI�� Ȱ��ȭ�Ǿ� �ֽ��ϴ�.");

        // 4. ���� ��ư Ŭ�� �׽�Ʈ
        settingsButton.GetComponent<Button>().onClick.Invoke();

        // ���� ȭ���� Ȱ��ȭ�Ǿ����� Ȯ��
        yield return null; // UI ���� ������Ʈ ���
        Assert.IsTrue(settingsUI.activeSelf, "Settings ��ư Ŭ�� �� Settings UI�� Ȱ��ȭ���� �ʾҽ��ϴ�.");

        // 5. ESC Ű �Է� �׽�Ʈ
        settingsUI.SetActive(false); // �ʱ� ���·� �缳��
        Assert.IsFalse(settingsUI.activeSelf, "ESC Ű �Է� �� Settings UI�� Ȱ��ȭ�Ǿ� �ֽ��ϴ�.");

        // ESC Ű �̺�Ʈ Ʈ����
        TriggerKeyPress(KeyCode.Escape);

        // ���� ȭ���� Ȱ��ȭ�Ǿ����� Ȯ��
        yield return null; // UI ���� ������Ʈ ���
        Assert.IsTrue(settingsUI.activeSelf, "ESC Ű �Է� �� Settings UI�� Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }

    // ESC Ű �Է� �ùķ��̼� �Լ�
    private void TriggerKeyPress(KeyCode keyCode)
    {
        // KeyDown �̺�Ʈ�� �������� Ʈ����
        var eventSystem = EventSystem.current;
        if (eventSystem != null)
        {
            var inputModule = eventSystem.currentInputModule as StandaloneInputModule;
            if (inputModule != null)
            {
                var fakeEvent = new UnityEngine.Event()
                {
                    type = EventType.KeyDown,
                    keyCode = keyCode,
                };
                Input.simulateMouseWithTouches = true; // Input System ��� �� ȣȯ
            }
        }
    }


    [UnityTest]
    public IEnumerator SettingsSlider_Test()
    {
        // 1. �� �ε� �Ϸ� ���
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        // 2. UI ��� ã��
        settingsButton = GameObject.Find("Button (ȯ�漳��)"); // ���� ��ư
        settingsUI = GameObject.Find("Panel (ȯ�漳��)");         // ���� ȭ��
        bgmSlider = GameObject.Find("MusicSlider"); // ����� �����̴�
        sfxSlider = GameObject.Find("SFXSlider"); // ȿ���� �����̴�
        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();

        // UI ��� Ȯ��
        Assert.IsNotNull(settingsButton, "Settings Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(settingsUI, "Settings UI�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(bgmSlider, "BGM Slider�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(sfxSlider, "SFX Slider�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(bgmAudioSource, "BGM AudioSource�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(sfxAudioSource, "SFX AudioSource�� ã�� �� �����ϴ�.");

        // 3. ���� UI Ȱ��ȭ
        settingsUI.SetActive(false); // �ʱ� ���� ����
        settingsButton.GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.IsTrue(settingsUI.activeSelf, "Settings UI�� Ȱ��ȭ���� �ʾҽ��ϴ�.");

        // 4. ����� �����̴� �׽�Ʈ
        var bgmSliderComponent = bgmSlider.GetComponent<Slider>();

        // �����̴� ���� ����
        bgmSliderComponent.value = 0.5f; // 50%�� ����
        yield return null;

        // AudioSource�� ���� Ȯ��
        Assert.AreEqual(0.5f, bgmAudioSource.volume, 0.01f, "����� ������ �����̴� ���� �ݿ����� �ʾҽ��ϴ�.");

        // 5. ȿ���� �����̴� �׽�Ʈ
        var sfxSliderComponent = sfxSlider.GetComponent<Slider>();

        // �����̴� ���� ����
        sfxSliderComponent.value = 0.8f; // 80%�� ����
        yield return null;

        // ȿ���� AudioSource ���� Ȯ��
        Assert.AreEqual(0.8f, sfxAudioSource.volume, 0.01f, "ȿ���� ������ �����̴� ���� �ݿ����� �ʾҽ��ϴ�.");
    }*/

}
