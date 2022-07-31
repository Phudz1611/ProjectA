using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;

    public Dropdown resolutiondropdown;


    void Start()
    {
        resolutions = Screen.resolutions;

        resolutiondropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentResolutionIndex;
        resolutiondropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityindex) {
        QualitySettings.SetQualityLevel(qualityindex);
    }
    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
