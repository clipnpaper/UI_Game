using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlBase : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // 초기값 설정
        volumeSlider.value = audioSource.volume;

        // 슬라이더 값 변경 시 Listner 호출
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }

    // Method called when the slider value changes
    public virtual void OnVolumeChange(float value)
    {
        // 슬라이더 변경 값 반영
        audioSource.volume = value;
    }

    protected virtual void Update()
    {

    }
}
