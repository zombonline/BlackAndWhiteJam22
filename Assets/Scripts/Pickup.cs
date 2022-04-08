using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private enum PICKUP_TYPE { TIME_UP, FOV_UP }

    [SerializeField] TextAsset textFile;
    [SerializeField] PICKUP_TYPE type;
    [SerializeField] float increaseTimeAmount;


    private PlayerFOV fov;

    private void Start()
    {
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == PICKUP_TYPE.FOV_UP)
        {
            GameObject.Find("Game Canvas").GetComponent<TextBox>().ShowText(textFile);
            PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), 1);
            fov.UpdateFOVUpgrades(true);
        }
        if(type == PICKUP_TYPE.TIME_UP)
        {
            FindObjectOfType<Clock>().IncreaseTimeRemaining(increaseTimeAmount);
        }

        GetComponent<EraseTile>().Erase();

    }
   
}
