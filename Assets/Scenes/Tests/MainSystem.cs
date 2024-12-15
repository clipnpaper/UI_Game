using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSystem : MonoBehaviour
{
    private static bool isInitialized = false;
    
    protected void Start()
    {
        // 로그인 버튼에 클릭 이벤트 추가
        // loginButton.onClick.AddListener(CheckLogin);

        // 입력 필드 기본 동작 제거
        if (!isInitialized)
        {
            InitializeCurrentScene();
            isInitialized = true;
        }
    }
    
    private void InitializeCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log($"Initializing {currentScene}");

        if (currentScene == "StageOneScene")
        {
            LoadStageOne();
        }
        else if (currentScene == "StageTwoScene")
        {
            LoadStageTwo();
        }
        else if (currentScene == "StageThreeScene")
        {
            LoadStageThree();
        }
        else if (currentScene == "StageFourScene")
        {
            LoadStageFour();
        }
    }
    
    public void LoadStageOne()
    {
        SceneManager.LoadScene("StageOneScene");
        Debug.Log("opening stage 1");
    }
    public void LoadStageTwo()
    {
        SceneManager.LoadScene("StageTwoScene");
        Debug.Log("opening stage 2");
    }
    
    public void LoadStageThree()
    {
        SceneManager.LoadScene("StageThreeScene");
        Debug.Log("opening stage 3");
    }
    public void LoadStageFour()
    {
        SceneManager.LoadScene("StageFourScene");
        Debug.Log("opening stage 4");
    }
    
}