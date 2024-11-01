using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtonClick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;
    public VolumeControlSFX volumeControlSFX;

    public void PlaySoundClick()
    {
        audioSource.volume = volumeControlSFX.audioSource.volume;
        audioSource.PlayOneShot(clickSound);
    }
}
