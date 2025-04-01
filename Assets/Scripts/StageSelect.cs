using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    // 버튼을 눌렀을 때 해당 스테이지 씬으로 이동하는 함수
    public void LoadStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }
}
