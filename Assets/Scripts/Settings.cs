using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    public AudioMixer audio;
    public GameManager data;
    public Slider mouseSensivitySlider;
    public TextMeshProUGUI mouseText;
    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown;
    Camera cam;
    MouseLook mouse;
    void Awake()
    {
        data = GameManager.instance;
        cam = Camera.main;
        mouse = cam.GetComponent<MouseLook>();

        mouseSensivitySlider.value = data.mouseSensitivity;
        volumeSlider.value = data.volume;
        qualityDropdown.value = (int)data.qualityLevel;
    }

    public void SetQuality(int quality){
        QualitySettings.SetQualityLevel(quality);
        data.qualityLevel = quality;
    }

    public void SetVolume(float volume){
        audio.SetFloat("volume", volume);
        data.volume = volume;
    }

    public void SetMouseSpeed(float speed){
        mouse.mouseSpeed = speed;
        data.mouseSensitivity = speed;
        mouseText.text = speed.ToString();
    }

}
