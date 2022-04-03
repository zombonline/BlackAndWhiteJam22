using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField] TextAsset textFile;
    [SerializeField] bool increaseTime, increaseFov;
    [SerializeField] float increaseTimeAmount, increaseFovAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Game Canvas").GetComponent<TextBox>().ShowText(textFile);
        if(increaseFov)
        {
            //increase fov
        }
        if(increaseTime)
        {
            FindObjectOfType<Clock>().IncreaseUnlockedTime(increaseTimeAmount);
        }

        Destroy(gameObject);
    }

   
}
