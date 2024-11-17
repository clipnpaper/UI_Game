using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSystem : MonoBehaviour
{
    public InputField idInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Button nextStageButton;
    public GameObject hintPanel; // Panel(힌트)
    public GameObject successPanel; // Panel(성공)
    public Slider musicSlider; // Slider 추가
    
    protected void Start()
    {
        // Panel 초기 상태 설정
        hintPanel.SetActive(false);
        successPanel.SetActive(false);

        // StageOne 실행 및 패널 전달
        StageOne stageOne = gameObject.AddComponent<StageOne>();
        stageOne.Initialize(idInputField, passwordInputField, loginButton, nextStageButton, hintPanel, successPanel);
    }

    /*public void LoadStageTwo()
    {
        Destroy(GetComponent<StageOne>());
        StageTwo stageTwo = gameObject.AddComponent<StageTwo>();
        stageTwo.Initialize(idInputField, passwordInputField, loginButton, hintPanel, successPanel);
    }*/
    
    public void LoadNextStage()
    {
        SceneManager.LoadScene("StageTwoScene");
        Destroy(GetComponent<StageOne>());
        StageTwo stageTwo = gameObject.AddComponent<StageTwo>();
        stageTwo.Initialize(idInputField, passwordInputField, loginButton, hintPanel, successPanel);
    }

}