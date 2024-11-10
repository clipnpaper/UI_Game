using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hintText;
    private HintSystem currentHint;

    public void LoadHintForLevel(int level)
    {
        if (currentHint != null)
        {
            Destroy(currentHint);
        }
        
        switch(level)
        {
            case 1:
                currentHint = gameObject.AddComponent<Level1Hint>();
                break;
            case 2:
                currentHint = gameObject.AddComponent<Level2Hint>();
                break;
            case 3:
                currentHint = gameObject.AddComponent<Level3Hint>();
                break;
            case 4:
                currentHint = gameObject.AddComponent<Level4Hint>();
                break;
            default:
                Debug.LogWarning("No Hint");
                return;
        }

        DisplayHint();
    }

    public void DisplayHint()
    {
        if (currentHint != null & hintText != null)
        {
            hintText.text = currentHint.GetHint();
        }
        else
        {
            hintText.text = "No Hint";
        }
    }
}
