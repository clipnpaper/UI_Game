using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        button.interactable = levelManager.levels[levelIndex].isUnlocked;
        button.onClick.AddListener(() => levelManager.LoadLevel(levelIndex));
    }
}
