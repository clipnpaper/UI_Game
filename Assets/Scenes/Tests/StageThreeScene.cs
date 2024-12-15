using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageThreeScene
{
    private GameObject usernameInputField;
    private GameObject passwordInputField;
    private GameObject loginButton;

    private GameObject loginPanel;          // 로그인 패널
    private GameObject draggablePanel; // 드래그 가능한 패널


    private GameObject cancelButton;       // 취소 버튼

    [SetUp]
    public void Setup()
    {
        // 스테이지 3 씬 로드
        SceneManager.LoadScene("StageThreeScene");
    }

    [UnityTest]
    public IEnumerator StageThree_InitialState_Test()
    {
        // 씬 로드 대기
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageThreeScene");
        yield return null;

        // UI 요소 초기화
        loginPanel = GameObject.Find("InputPanel");
        draggablePanel = GameObject.Find("Title");
        cancelButton = GameObject.Find("Button (취소)");

        loginButton = GameObject.Find("Button (로그인)");
        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");

        // 초기 상태 확인
        Assert.IsNotNull(loginPanel, "Login Panel을 찾을 수 없습니다.");
        Assert.IsNotNull(cancelButton, "Cancel Button을 찾을 수 없습니다.");
        Assert.IsNotNull(loginButton, "Login Button을 찾을 수 없습니다.");
        Assert.IsNotNull(usernameInputField, "ID Input Field를 찾을 수 없습니다.");
        Assert.IsNotNull(passwordInputField, "Password Input Field를 찾을 수 없습니다.");

        // 초기 비활성 상태 확인
        
    }

    

    [UnityTest]
    public IEnumerator Login_Input_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageThreeScene");
        yield return null;

        loginPanel = GameObject.Find("InputPanel");
        draggablePanel = GameObject.Find("Title");
        cancelButton = GameObject.Find("Button (취소)");

        // UI 요소 초기화
        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (로그인)");

        var rectTransform = loginPanel.GetComponent<RectTransform>();
        Assert.IsNotNull(rectTransform, "패널에 RectTransform이 없습니다.");
        var rectTransform2 = draggablePanel.GetComponent<RectTransform>();
        Assert.IsNotNull(rectTransform2, "패널에 RectTransform이 없습니다.");

        // 초기 위치 저장
        Vector2 initialPosition = rectTransform.anchoredPosition;
        Vector2 initialPosition2 = rectTransform2.anchoredPosition;

        var eventData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(300, 300) // 드래그 위치 (스크린 좌표)
        };

        // OnBeginDrag 호출
        ExecuteEvents.Execute(draggablePanel, eventData, ExecuteEvents.beginDragHandler);
        ExecuteEvents.Execute(loginPanel, eventData, ExecuteEvents.beginDragHandler);

        // OnDrag 호출 (드래그 이동)
        eventData.position = new Vector2(500, 500); // 새로운 드래그 위치
        ExecuteEvents.Execute(draggablePanel, eventData, ExecuteEvents.dragHandler);
        ExecuteEvents.Execute(loginPanel, eventData, ExecuteEvents.dragHandler);

        // OnEndDrag 호출
        ExecuteEvents.Execute(draggablePanel, eventData, ExecuteEvents.endDragHandler);
        ExecuteEvents.Execute(loginPanel, eventData, ExecuteEvents.endDragHandler);

        yield return null; // 드래그 완료 후 1 프레임 대기
        Vector2 finalPosition = rectTransform.anchoredPosition;
        Vector2 finalPosition2 = rectTransform2.anchoredPosition;

        // ID/PW 필드에 값 입력
        var usernameField = usernameInputField.GetComponent<InputField>();
        var passwordField = passwordInputField.GetComponent<InputField>();

        usernameField.text = "admin";
        passwordField.text = "1234";

        // 로그인 버튼 클릭
        var loginButtonComponent = loginButton.GetComponent<Button>();
        Assert.IsNotNull(loginButtonComponent, "로그인 버튼에 Button 컴포넌트가 없습니다.");
        loginButtonComponent.onClick.Invoke();

        yield return null;

    }

    /*[UnityTest]
    public IEnumerator StageThree_HintPanel_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageThreeScene");
        yield return null;

        // 힌트 버튼 클릭 후 힌트 패널 활성화 확인
        var hintButton = GameObject.Find("HintButton");
        Assert.IsNotNull(hintButton, "힌트 버튼을 찾을 수 없습니다.");

        var hintButtonComponent = hintButton.GetComponent<Button>();
        Assert.IsNotNull(hintButtonComponent, "힌트 버튼에 Button 컴포넌트가 없습니다.");

        hintButtonComponent.onClick.Invoke();
        yield return null;

        Assert.IsTrue(hintPanel.activeSelf, "Hint 버튼 클릭 후 Hint Panel이 활성화되지 않았습니다.");
    }*/


}
