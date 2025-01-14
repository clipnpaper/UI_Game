using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAnimationController : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        // 1초 뒤에 Panel 비활성화
        Invoke("DisablePanel", 1.95f);
    }

    void DisablePanel()
    {
        panel.SetActive(false);
    }
}
