using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;

        Screen.SetResolution(640, 360, true);

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else if (PlayerPrefs.HasKey("soundVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSoundVolume();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("ExposedMusic", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        myMixer.SetFloat("ExposedSound", volume);
        PlayerPrefs.SetFloat("soundVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");

        SetMusicVolume();
        SetSoundVolume();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Player has quit");
        Application.Quit();
    }
}
