using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour
{
    public GameObject adWindow;
    public RectTransform closeButton;
    private bool doClose = false;
    
    // Start is called before the first frame update
    void Start()
    {
        adWindow.SetActive(true);
    }
    public void OnClick()
    {
        doClose = true;
        // 여기서 버튼 클릭 시 실행할 코드 작성
        Debug.Log("close clicked!");
    }
    // Update is called once per frame
    void Update()
    {
        if (doClose)
        {
            adWindow.SetActive(false);
        }
    }
}
