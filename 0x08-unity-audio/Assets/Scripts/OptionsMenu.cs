using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string bgmPref = "bgmPref";
    private static readonly string sfxPref = "sfxPref";
    private int firstPlayInt;
    public Slider sfxSlider, bgmSlider;
    private float sfxFloat, bgmFloat;
    public AudioSource bgmAudio;
    public AudioSource[] sfxAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("InvertY"))
        {
            this.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("InvertY") == 0 ? false : true;
        }
        else
        {
            this.GetComponentInChildren<Toggle>().isOn = false;
        }

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            bgmFloat = .25f;
            sfxFloat = .75f;
            bgmSlider.value = bgmFloat;
            sfxSlider.value = sfxFloat;
            PlayerPrefs.SetFloat(bgmPref, bgmFloat);
            PlayerPrefs.SetFloat(sfxPref, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {

            bgmFloat = PlayerPrefs.GetFloat(bgmPref);
            bgmSlider.value = bgmFloat;
           
            sfxFloat = PlayerPrefs.GetFloat(sfxPref);
            sfxSlider.value = sfxFloat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(bgmPref, bgmSlider.value);
        PlayerPrefs.SetFloat(sfxPref, sfxSlider.value);
    }

    public void OnApplicationFocus(bool infocus)
    {
        if(!infocus)
        {
            SaveSoundSetting();
        }
    }

    public void Apply()
    {
        PlayerPrefs.SetInt("InvertY", this.GetComponentInChildren<Toggle>().isOn ? 1 : 0);
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
        SaveSoundSetting();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateSound()
    {
        Debug.Log("UpdateSoundSettings");
        bgmAudio.volume = bgmSlider.value;
        for (int i = 0; i < sfxAudio.Length; i++)
        {
            sfxAudio[i].volume = sfxSlider.value;
        }
    }
}
