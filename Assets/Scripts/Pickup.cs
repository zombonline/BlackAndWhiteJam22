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

    [SerializeField] private int collectableID = 0;

    private PlayerSound sound;
    private PlayerFOV fov;

    private void Start()
    {
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
        sound = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSound>();

        //declare the playerpref if it does not already exist
        if (type == PICKUP_TYPE.FOV_UP)
        {
            if(!PlayerPrefs.HasKey("Level" + SceneManager.GetActiveScene().buildIndex.ToString()))
            {
                PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), 0);
            }
            //get rid of pickup if playerpref exists and pickup has been collected.
            else if(PlayerPrefs.GetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString()) > 0)
            {
                GetComponent<EraseTile>().Erase();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == PICKUP_TYPE.FOV_UP)
        {
            sound.PlayCollectableSound();
            GameObject.Find("Game Canvas").GetComponent<TextBox>().ShowText(textFile);
            PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), 1);
            fov.UpdateFOVUpgrades(true);

        }
        if(type == PICKUP_TYPE.TIME_UP)
        {
            FindObjectOfType<Clock>().IncreaseTimeRemaining(increaseTimeAmount);
            sound.PlayClockSound(increaseTimeAmount);
        }

        GetComponent<EraseTile>().Erase();

    }
   
}
