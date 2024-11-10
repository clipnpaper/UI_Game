using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string sceneName;
        public bool isUnlocked;
    }

    public List<Level> levels = new List<Level>();

    private void Start()
    {
        LoadLevelProgress();
    }

    public void UnlockNextLevel(int currentLevelIndex)
    {
        if (currentLevelIndex <  levels.Count - 1)
        {
            levels[currentLevelIndex + 1].isUnlocked = true;
            SaveLevelProgress();
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levels[levelIndex].isUnlocked)
        {
            SceneManager.LoadScene(levels[levelIndex].sceneName);
        }
        else{
            Debug.Log("Level Locked");
        }
    }

    private void SaveLevelProgress()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            PlayerPrefs.SetInt("LevelUnlocked_" + i, levels[i].isUnlocked ? 1: 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadLevelProgress()
    {
        // 저장된 데이터가 없을 경우 기본적으로 level[0] 만 unlock 된 상태, 있을 경우 그 데이터를 가져옴
        for (int i = 0; i< levels.Count; i++)
        {
            levels[i].isUnlocked = PlayerPrefs.GetInt("LevelUnlocked_" + i, i == 0 ? 1 : 0) == 1;
        }
    }
}
