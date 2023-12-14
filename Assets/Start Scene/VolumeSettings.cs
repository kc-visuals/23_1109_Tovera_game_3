using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    private static VolumeSettings instance;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider audioSlider;
    [SerializeField] private AudioSource[] audioSources;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSlider.value = GetVolume();
        audioSlider.onValueChanged.AddListener(SetVolume);
    }
    public void SetVolume(float volume)
    {
        foreach (var audioSource in audioSources)
        {
            // Adjust the volume of each AudioSource individually
            audioSource.volume = volume;
        }
        myMixer.SetFloat("GameVolume", Mathf.Log10(volume) * 20);
    }

    public float GetVolume()
    {
       
        return audioSources.Length > 0 ? audioSources[0].volume : 1.0f;
    }
}
