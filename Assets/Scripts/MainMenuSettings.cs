using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MainMenuSettings : MonoBehaviour
{
    public AudioMixer audio;
    public GameManager data;
    public Slider mouseSensivitySlider;
    public TextMeshProUGUI mouseText;
    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown;
    void Start()
    {
        data = GameManager.instance;
        mouseSensivitySlider.value = data.mouseSensitivity;
        volumeSlider.value = data.volume;
        qualityDropdown.value = (int)data.qualityLevel;
    }

    // Update is called once per frame
    public void SetQuality(int quality){
        QualitySettings.SetQualityLevel(quality);
        data.qualityLevel = quality;
    }

    public void SetVolume(float volume){
        audio.SetFloat("volume", volume);
        data.volume = volume;
    }

    public void SetMouseSpeed(float speed){
        data.mouseSensitivity = speed;
        mouseText.text = speed.ToString();
    }
}
