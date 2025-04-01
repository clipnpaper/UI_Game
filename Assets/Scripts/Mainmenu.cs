using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");  // 스테이지 선택 화면으로 이동
    }

    public void QuitGame()
    {
        Application.Quit();  // 게임 종료 (에디터에서는 동작하지 않음)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}