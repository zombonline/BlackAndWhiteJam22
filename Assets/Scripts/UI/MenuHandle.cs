using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject menu, options;
    [SerializeField]
    private Slider master, music, effects;
    [SerializeField]
    private Button keyboardButton, mouseButton;
    [SerializeField]
    private AudioMixer mixer;

    public const string KEYBOARD_CONTROLS = "Keyboard";
    public const string KEYBOARD_AND_MOUSE_CONTROLS = "KeyboardAndMouse";


    // Start is called before the first frame update
    void Start()
    {
        if (!CompareTag("Pause"))
        {
            Menu();
        }
        else
        {
            ClosePauseMenu();
        }
        SetupOptions();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Options()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

    public void Menu()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void UpdateMaster()
    {
        PlayerPrefs.SetFloat("MasterVolume", master.value);
        UpdateAudio();
    }

    public void UpdateMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", music.value);
        UpdateAudio();
    }
    public void UpdateEffects()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effects.value);
        UpdateAudio();
    }

    public void ResetOptions()
    {
        PlayerPrefs.SetFloat("MasterVolume", 1);
        PlayerPrefs.SetFloat("MusicVolume", 1);
        PlayerPrefs.SetFloat("EffectsVolume", 1);

        PlayerPrefs.SetString("Controls", KEYBOARD_AND_MOUSE_CONTROLS);

        SetupOptions();
    }


    public void UpdateAudio()
    {
        mixer.SetFloat("Master", Mathf.Log(PlayerPrefs.GetFloat("MasterVolume")) * 20f);
        mixer.SetFloat("Music", Mathf.Log(PlayerPrefs.GetFloat("MusicVolume")) * 20f);
        mixer.SetFloat("Effects", Mathf.Log(PlayerPrefs.GetFloat("EffectsVolume")) * 20f);
    }


    public void SetControlsToKeyboard()
    {
        PlayerPrefs.SetString("Controls", KEYBOARD_CONTROLS);
        mouseButton.interactable = true;
        keyboardButton.interactable = false;
    }

    public void SetControlsToKeyboardAndMouse()
    {
        PlayerPrefs.SetString("Controls", KEYBOARD_AND_MOUSE_CONTROLS);
        mouseButton.interactable = false;
        keyboardButton.interactable = true;
    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        options.SetActive(false);
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
        options.SetActive(false);
    }

    public bool CheckMenusActive()
    {
        return menu.activeInHierarchy || options.activeInHierarchy;
    }

    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectScene");
    }

    public void OpenMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        SetupOptions();
    }

    private void SetupOptions()
    {
        //check player prefs set
        if (PlayerPrefs.GetFloat("MasterVolume").Equals(0) || PlayerPrefs.GetFloat("MusicVolume").Equals(0) || PlayerPrefs.GetFloat("EffectsVolume").Equals(0))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetFloat("EffectsVolume", 1);
        }

        master.value = PlayerPrefs.GetFloat("MasterVolume");
        music.value = PlayerPrefs.GetFloat("MusicVolume");
        effects.value = PlayerPrefs.GetFloat("EffectsVolume");

        if (PlayerPrefs.GetString("Controls").Equals(""))
        {
            PlayerPrefs.SetString("Controls", KEYBOARD_AND_MOUSE_CONTROLS);
        }

        if (PlayerPrefs.GetString("Controls").Equals(KEYBOARD_CONTROLS))
        {
            keyboardButton.interactable = false;
            mouseButton.interactable = true;
        }
        else
        {
            mouseButton.interactable = false;
            keyboardButton.interactable = true;
        }

        //setting levels unlocked
        if (PlayerPrefs.GetInt("LevelsUnlocked").Equals(0))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", 1);
        }
    }
}
