using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle toggle;
    private bool mute;

    public void Start()
    {
        mute = bool.Parse(PlayerPrefs.GetString("mute", "false"));
        if (mute)
        {
            toggle.isOn = false;
        }
        MuteMusic();
    }

    public void Update()
    {
        ChangeSettings();
        MuteMusic();
    }

    public void MuteMusic()
    {
        if (!mute)
        {
            audioMixer.SetFloat("music", 0);
            AudioListener.volume = 0f;
        }
        if(mute)
        {
            audioMixer.SetFloat("music", -80);
            AudioListener.volume = 1f;
        }
    }

    public void ChangeSettings()
    {
        if (!toggle.isOn)
        {
            PlayerPrefs.SetString("mute", "false");
            mute = false;
        }
        if (toggle.isOn)
        {
            PlayerPrefs.SetString("mute", "true");
            mute = true;
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
