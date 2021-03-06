using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartTextHandle : MonoBehaviour
{
    PlayerFOV fov;
    MenuHandle menu;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Pause").GetComponent<MenuHandle>();
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
        fov.gameObject.SetActive(true);
        if (transform.localPosition.x > 10 && PlayerPrefs.GetString("Controls").Equals(MenuHandle.KEYBOARD_CONTROLS))
        {
            GetComponent<TextMeshProUGUI>().text = "Arrow keys to look around";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.OpenPauseMenu();
        }
        else if (Input.anyKeyDown && !menu.CheckMenusActive())
        {
            fov.gameObject.SetActive(true);
            Time.timeScale = 1f;
            Destroy(this.gameObject);
        }
        else
        {
            //wait for input to start clock
            fov.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
