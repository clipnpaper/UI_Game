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
        // StageOneScene을 로드합니다.
        SceneManager.LoadScene("StageOneScene");
    }

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator Mainsystem_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (로그인)");
        settingsButton = GameObject.Find("Button (환경설정)"); // 설정 버튼
        settingsUI = GameObject.Find("Panel (환경설정)");         // 설정 화면
        bgmSlider = GameObject.Find("MusicSlider"); // 배경음 슬라이더
        sfxSlider = GameObject.Find("SFXSlider"); // 효과음 슬라이더
        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();
        //hintButton = GameObject.Find("Button (힌트)");
        //hintUI = GameObject.Find("Panel (힌트)");
        //closeHintButton = GameObject.Find("Button (hintGoBack)"); // 힌트 끄기 버튼
        
        //Assert.IsNotNull(hintButton, "Hint Button을 찾을 수 없습니다.");
        //Assert.IsNotNull(closeHintButton, "Close Hint Button을 찾을 수 없습니다.");
        //Assert.IsNotNull(hintUI, "Hint UI를 찾을 수 없습니다.");

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

        // 3. InputField에 텍스트 입력
        settingsButton.GetComponent<Button>().onClick.Invoke();

        var bgmSliderComponent = bgmSlider.GetComponent<Slider>();
        var sfxSliderComponent = sfxSlider.GetComponent<Slider>();

        // 슬라이더 값을 변경
        sfxSliderComponent.value = 0.8f; // 80%로 설정
        // 슬라이더 값을 변경
        bgmSliderComponent.value = 0.5f; // 50%로 설정
        // ESC 키 이벤트 트리거
        TriggerKeyPress(KeyCode.Escape);

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

    private void TriggerKeyPress(KeyCode keyCode)
    {
        // KeyDown 이벤트를 수동으로 트리거
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
                Input.simulateMouseWithTouches = true; // Input System 사용 시 호환
            }
        }
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Hint_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        hintButton = GameObject.Find("Button (힌트)");
        hintUI = GameObject.Find("Panel (힌트)");
        closeHintButton = GameObject.Find("Button (hintGoBack)"); // 힌트 끄기 버튼

        Assert.IsNotNull(hintButton, "Hint Button을 찾을 수 없습니다.");
        Assert.IsNotNull(closeHintButton, "Close Hint Button을 찾을 수 없습니다.");
        Assert.IsNotNull(hintUI, "Hint UI를 찾을 수 없습니다.");

        hintUI.SetActive(false); // 초기 상태에서 힌트 UI는 비활성화되어 있어야 함
        Assert.IsFalse(hintUI.activeSelf, "초기 상태에서 Hint UI가 활성화되어 있습니다.");

        hintButton.GetComponent<Button>().onClick.Invoke();

        yield return null; // UI 상태가 업데이트되도록 한 프레임 대기

        Assert.IsTrue(hintUI.activeSelf, "Hint 버튼 클릭 후 Hint UI가 활성화되지 않았습니다.");

        // 4. 힌트 끄기 버튼 클릭
        closeHintButton.GetComponent<Button>().onClick.Invoke();

        yield return null; // UI 상태 업데이트 대기
        Assert.IsFalse(hintUI.activeSelf, "Close Hint 버튼 클릭 후 Hint UI가 비활성화되지 않았습니다.");
    }
    /*
    [UnityTest]
    public IEnumerator SettingsButton_And_EscKey_Test()
    {
        // 1. 씬 로드 완료 대기
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        // 2. UI 요소 찾기
        settingsButton = GameObject.Find("Button (환경설정)"); // 설정 버튼
        settingsUI = GameObject.Find("Panel (환경설정)");         // 설정 화면


        // UI 요소 확인
        Assert.IsNotNull(settingsButton, "Settings Button을 찾을 수 없습니다.");
        Assert.IsNotNull(settingsUI, "Settings UI를 찾을 수 없습니다.");

        // 3. 초기 상태: 설정 화면이 비활성화되어 있어야 함
        settingsUI.SetActive(false); // 초기 상태 설정
        Assert.IsFalse(settingsUI.activeSelf, "초기 상태에서 Settings UI가 활성화되어 있습니다.");

        // 4. 설정 버튼 클릭 테스트
        settingsButton.GetComponent<Button>().onClick.Invoke();

        // 설정 화면이 활성화되었는지 확인
        yield return null; // UI 상태 업데이트 대기
        Assert.IsTrue(settingsUI.activeSelf, "Settings 버튼 클릭 후 Settings UI가 활성화되지 않았습니다.");

        // 5. ESC 키 입력 테스트
        settingsUI.SetActive(false); // 초기 상태로 재설정
        Assert.IsFalse(settingsUI.activeSelf, "ESC 키 입력 전 Settings UI가 활성화되어 있습니다.");

        // ESC 키 이벤트 트리거
        TriggerKeyPress(KeyCode.Escape);

        // 설정 화면이 활성화되었는지 확인
        yield return null; // UI 상태 업데이트 대기
        Assert.IsTrue(settingsUI.activeSelf, "ESC 키 입력 후 Settings UI가 활성화되지 않았습니다.");
    }

    // ESC 키 입력 시뮬레이션 함수
    private void TriggerKeyPress(KeyCode keyCode)
    {
        // KeyDown 이벤트를 수동으로 트리거
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
                Input.simulateMouseWithTouches = true; // Input System 사용 시 호환
            }
        }
    }


    [UnityTest]
    public IEnumerator SettingsSlider_Test()
    {
        // 1. 씬 로드 완료 대기
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageOneScene");

        // 2. UI 요소 찾기
        settingsButton = GameObject.Find("Button (환경설정)"); // 설정 버튼
        settingsUI = GameObject.Find("Panel (환경설정)");         // 설정 화면
        bgmSlider = GameObject.Find("MusicSlider"); // 배경음 슬라이더
        sfxSlider = GameObject.Find("SFXSlider"); // 효과음 슬라이더
        var bgmAudioSource = GameObject.Find("Music Audio Source").GetComponent<AudioSource>();
        var sfxAudioSource = GameObject.Find("SFX Audio Source").GetComponent<AudioSource>();

        // UI 요소 확인
        Assert.IsNotNull(settingsButton, "Settings Button을 찾을 수 없습니다.");
        Assert.IsNotNull(settingsUI, "Settings UI를 찾을 수 없습니다.");
        Assert.IsNotNull(bgmSlider, "BGM Slider를 찾을 수 없습니다.");
        Assert.IsNotNull(sfxSlider, "SFX Slider를 찾을 수 없습니다.");
        Assert.IsNotNull(bgmAudioSource, "BGM AudioSource를 찾을 수 없습니다.");
        Assert.IsNotNull(sfxAudioSource, "SFX AudioSource를 찾을 수 없습니다.");

        // 3. 설정 UI 활성화
        settingsUI.SetActive(false); // 초기 상태 설정
        settingsButton.GetComponent<Button>().onClick.Invoke();
        yield return null;
        Assert.IsTrue(settingsUI.activeSelf, "Settings UI가 활성화되지 않았습니다.");

        // 4. 배경음 슬라이더 테스트
        var bgmSliderComponent = bgmSlider.GetComponent<Slider>();

        // 슬라이더 값을 변경
        bgmSliderComponent.value = 0.5f; // 50%로 설정
        yield return null;

        // AudioSource의 볼륨 확인
        Assert.AreEqual(0.5f, bgmAudioSource.volume, 0.01f, "배경음 볼륨이 슬라이더 값에 반영되지 않았습니다.");

        // 5. 효과음 슬라이더 테스트
        var sfxSliderComponent = sfxSlider.GetComponent<Slider>();

        // 슬라이더 값을 변경
        sfxSliderComponent.value = 0.8f; // 80%로 설정
        yield return null;

        // 효과음 AudioSource 볼륨 확인
        Assert.AreEqual(0.8f, sfxAudioSource.volume, 0.01f, "효과음 볼륨이 슬라이더 값에 반영되지 않았습니다.");
    }*/

}
