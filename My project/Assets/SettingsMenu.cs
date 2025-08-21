using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer AM;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> AllResolutions = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            AllResolutions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(AllResolutions);

        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution toSet = resolutions[resolutionIndex];
        Screen.SetResolution(toSet.width, toSet.height, Screen.fullScreen);
    }


    public void setVolume(float toSet)
    {
        AM.SetFloat("MasterVolume", toSet);

    }

    public void setQuality(int chosenQual)
    {
        QualitySettings.SetQualityLevel(chosenQual);
    }

    public void setFullscreen(bool Full)
    {
        Screen.fullScreen = Full;
    }
}
