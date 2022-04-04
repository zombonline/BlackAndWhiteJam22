using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, optionsMenu;
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
        Menu();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");

        //check player prefs set
        if (PlayerPrefs.GetFloat("MasterVolume").Equals(0) || PlayerPrefs.GetFloat("MusicVolume").Equals(0) || PlayerPrefs.GetFloat("EffectsVolume").Equals(0))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetFloat("EffectsVolume", 1);
        }

        if (PlayerPrefs.GetString("Controls").Equals(""))
        {
            PlayerPrefs.SetString("Controls", KEYBOARD_CONTROLS);
        }
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Menu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
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

    public void ResetAudio()
    {
        master.value = 1;
        music.value = 1;
        effects.value = 1;
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
    }

    public void SetControlsToKeyboardAndMouse()
    {
        PlayerPrefs.SetString("Controls", KEYBOARD_AND_MOUSE_CONTROLS);
    }
}
