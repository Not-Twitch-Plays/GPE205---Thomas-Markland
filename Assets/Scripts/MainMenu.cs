using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider sensSlider;
    public TMP_Dropdown povDropdown;

    private void Awake()
    {
        EnableMainMenu();
        if (GameManager.instance != null)
        {
            GameManager.instance.players.Clear();
        }
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void EnableOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

        musicSlider.value = PlayerPrefs.GetFloat("Music Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        sensSlider.value = PlayerPrefs.GetFloat("Turn Sensitivity");
        povDropdown.value = PlayerPrefs.GetInt("POV");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("Music Volume", value);
    }
    public void SetSFXVoume(float value)
    {
        PlayerPrefs.SetFloat("SFX Volume", value);
    }
    public void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat("Turn Sensitivity", value);
    }
    public void SetPOV(int value)
    {
        PlayerPrefs.SetInt("POV", value);
    }
}
