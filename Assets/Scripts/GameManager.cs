using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 게임매니저 객체
    public static GameManager Instance { get; private set; }

    //[SerializeField] private LevelManager levelManager;
    [SerializeField] private HintManager hintManager;
    //[SerializeField] private VolumeControlMusic musicManager;
    //[SerializeField] private VolumeControlSFX sfxManager;

    // 객체 하나로 유지
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnLevelStart(int level)
    {
        // 현재 힌트매니저 탐색
        HintManager sceneHintManager = FindObjectOfType<HintManager>();
        if (sceneHintManager != null)
        {
            hintManager = sceneHintManager; // 레벨 변화시 마다 힌트매니저 재할당
            hintManager.LoadHintForLevel(level);
            Debug.Log($"Loading hint for level {level}");
        }
        else
        {
            Debug.LogWarning("No HintManager found in the current scene.");
        }
    }
}
