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

    private GameObject loginPanel;          // �α��� �г�
    private GameObject draggablePanel; // �巡�� ������ �г�


    private GameObject cancelButton;       // ��� ��ư

    [SetUp]
    public void Setup()
    {
        // �������� 3 �� �ε�
        SceneManager.LoadScene("StageThreeScene");
    }

    [UnityTest]
    public IEnumerator StageThree_InitialState_Test()
    {
        // �� �ε� ���
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageThreeScene");
        yield return null;

        // UI ��� �ʱ�ȭ
        loginPanel = GameObject.Find("InputPanel");
        draggablePanel = GameObject.Find("Title");
        cancelButton = GameObject.Find("Button (���)");

        loginButton = GameObject.Find("Button (�α���)");
        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");

        // �ʱ� ���� Ȯ��
        Assert.IsNotNull(loginPanel, "Login Panel�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(cancelButton, "Cancel Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(loginButton, "Login Button�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(usernameInputField, "ID Input Field�� ã�� �� �����ϴ�.");
        Assert.IsNotNull(passwordInputField, "Password Input Field�� ã�� �� �����ϴ�.");

        // �ʱ� ��Ȱ�� ���� Ȯ��
        
    }

    

    [UnityTest]
    public IEnumerator Login_Input_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageThreeScene");
        yield return null;

        loginPanel = GameObject.Find("InputPanel");
        draggablePanel = GameObject.Find("Title");
        cancelButton = GameObject.Find("Button (���)");

        // UI ��� �ʱ�ȭ
        usernameInputField = GameObject.Find("InputField (ID)");
        passwordInputField = GameObject.Find("InputField (PW)");
        loginButton = GameObject.Find("Button (�α���)");

        var rectTransform = loginPanel.GetComponent<RectTransform>();
        Assert.IsNotNull(rectTransform, "�гο� RectTransform�� �����ϴ�.");
        var rectTransform2 = draggablePanel.GetComponent<RectTransform>();
        Assert.IsNotNull(rectTransform2, "�гο� RectTransform�� �����ϴ�.");

        // �ʱ� ��ġ ����
        Vector2 initialPosition = rectTransform.anchoredPosition;
        Vector2 initialPosition2 = rectTransform2.anchoredPosition;

        var eventData = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(300, 300) // �巡�� ��ġ (��ũ�� ��ǥ)
        };

        // OnBeginDrag ȣ��
        ExecuteEvents.Execute(draggablePanel, eventData, ExecuteEvents.beginDragHandler);
        ExecuteEvents.Execute(loginPanel, eventData, ExecuteEvents.beginDragHandler);

        // OnDrag ȣ�� (�巡�� �̵�)
        eventData.position = new Vector2(500, 500); // ���ο� �巡�� ��ġ
        ExecuteEvents.Execute(draggablePanel, eventData, ExecuteEvents.dragHandler);
        ExecuteEvents.Execute(loginPanel, eventData, ExecuteEvents.dragHandler);

        // OnEndDrag ȣ��
        ExecuteEvents.Execute(draggablePanel, eventData, ExecuteEvents.endDragHandler);
        ExecuteEvents.Execute(loginPanel, eventData, ExecuteEvents.endDragHandler);

        yield return null; // �巡�� �Ϸ� �� 1 ������ ���
        Vector2 finalPosition = rectTransform.anchoredPosition;
        Vector2 finalPosition2 = rectTransform2.anchoredPosition;

        // ID/PW �ʵ忡 �� �Է�
        var usernameField = usernameInputField.GetComponent<InputField>();
        var passwordField = passwordInputField.GetComponent<InputField>();

        usernameField.text = "admin";
        passwordField.text = "1234";

        // �α��� ��ư Ŭ��
        var loginButtonComponent = loginButton.GetComponent<Button>();
        Assert.IsNotNull(loginButtonComponent, "�α��� ��ư�� Button ������Ʈ�� �����ϴ�.");
        loginButtonComponent.onClick.Invoke();

        yield return null;

    }

    /*[UnityTest]
    public IEnumerator StageThree_HintPanel_Test()
    {
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "StageThreeScene");
        yield return null;

        // ��Ʈ ��ư Ŭ�� �� ��Ʈ �г� Ȱ��ȭ Ȯ��
        var hintButton = GameObject.Find("HintButton");
        Assert.IsNotNull(hintButton, "��Ʈ ��ư�� ã�� �� �����ϴ�.");

        var hintButtonComponent = hintButton.GetComponent<Button>();
        Assert.IsNotNull(hintButtonComponent, "��Ʈ ��ư�� Button ������Ʈ�� �����ϴ�.");

        hintButtonComponent.onClick.Invoke();
        yield return null;

        Assert.IsTrue(hintPanel.activeSelf, "Hint ��ư Ŭ�� �� Hint Panel�� Ȱ��ȭ���� �ʾҽ��ϴ�.");
    }*/


}
