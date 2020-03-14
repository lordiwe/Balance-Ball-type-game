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
        //mute = JsonUtility.FromJson<bool>(jsonString);
        //mute = (PlayerPrefs.GetInt("mute") != 0 );
        mute = bool.Parse(PlayerPrefs.GetString("mute", "false"));
        Debug.LogWarning(mute);
        ChangeToggle();
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

    public void ChangeToggle()
    {
        if(mute)
        {
            toggle.isOn = false;
        }
        if (!mute)
        {
            toggle.isOn = true;
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
        //PlayerPrefs.SetString("mute", mute.ToString());
        //PlayerPrefs.SetInt("mute", (mute ? 1 : 0));
        PlayerPrefs.Save();
    }
}
