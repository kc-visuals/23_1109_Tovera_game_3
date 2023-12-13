using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider audioSlider;

    public void SetGameVolume()
    {
        float volume = audioSlider.value;
        myMixer.SetFloat("GameAudio", volume);
    }
}
