using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private enum PICKUP_TYPE { TIME_UP, FOV_UP }

    //[SerializeField] TextAsset textFile;
    [SerializeField] PICKUP_TYPE type;
    [SerializeField] float increaseTimeAmount;

    private PlayerSound sound;
    private PlayerFOV fov;
    [SerializeField]
    private TextAsset collectableText;

    private void Start()
    {
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
        sound = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSound>();

        //declare the playerpref if it does not already exist
        if (type == PICKUP_TYPE.FOV_UP)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            if(!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 0);
            }
            //get rid of pickup if playerpref exists and pickup has been collected.
            else if(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) > 0)
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
            GameObject.Find("Game Canvas").GetComponent<TextBox>().ShowText(collectableText);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
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
