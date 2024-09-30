using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public VolumenSettings volumenSettings; 
    public AudioMixer audioMixer;  

    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        masterSlider.value = 1;
        musicSlider.value = 1;
        sfxSlider.value = 1;

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        Volumes();
    }

    public void SetMasterVolume(float volume)
    {
        volumenSettings.masterVolumen = volume;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        volumenSettings.musicVolumen = volume;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        volumenSettings.sfxVolumen = volume;
        audioMixer.SetFloat("Sounds", Mathf.Log10(volume) * 20);
    }

    public void Volumes()
    {
        audioMixer.SetFloat("Master", 0);
        audioMixer.SetFloat("Music", 0);
        audioMixer.SetFloat("Sounds", 0);
    }
}
