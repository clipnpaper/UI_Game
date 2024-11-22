using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlBase : MonoBehaviour
{
    public Slider volumeSlider; // Volume Slider
    public AudioSource audioSource; // AudioSource
    public RectTransform inputPanel; // InputPanel 연결

    protected Vector3 panelStartPosition; // InputPanel의 초기 위치
    protected Vector3 panelTargetPosition; // InputPanel의 이동 목표 위치

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // AudioSource와 Slider 초기값 동기화
        volumeSlider.value = audioSource.volume;

        // Slider 값 변경 시 OnVolumeChange 호출
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);

        // InputPanel 초기 위치 설정
        if (inputPanel != null)
        {
            panelStartPosition = inputPanel.anchoredPosition;
            panelTargetPosition = panelStartPosition;
        }
    }

    // Slider 값 변경 시 호출되는 메서드
    public virtual void OnVolumeChange(float value)
    {
        // AudioSource의 볼륨 조정
        audioSource.volume = value;

        // Slider 값에 따라 InputPanel 이동
        if (inputPanel != null)
        {
            float panelOffset = value * 500f; // 이동 범위 설정 (500은 적당히 조정 가능)
            panelTargetPosition = panelStartPosition + new Vector3(panelOffset, 0, 0); // X축으로 이동
        }
    }

    // 매 프레임 호출
    protected virtual void Update()
    {
        // InputPanel을 목표 위치로 부드럽게 이동
        if (inputPanel != null)
        {
            inputPanel.anchoredPosition = Vector3.MoveTowards(
                inputPanel.anchoredPosition,
                panelTargetPosition,
                2000f * Time.deltaTime // 속도 조정 가능
            );
        }
    }
}

