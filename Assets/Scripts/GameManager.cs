using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 게임매니저 객체
    public static GameManager Instance { get; private set; }
    [SerializeField] private HintManager hintManager;

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
        if (hintManager != null)
        {
            hintManager.LoadHintForLevel(level);
        }
    }
}
