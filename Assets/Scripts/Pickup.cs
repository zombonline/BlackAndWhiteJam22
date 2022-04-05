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

    private InversePickup inversePickup;

    private PlayerFOV fov;

    private void Start()
    {
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<PlayerFOV>();
        inversePickup = GetComponentInChildren<InversePickup>();
    }

    public void RevealInverse()
    {
        inversePickup.Spotted();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(increaseFov)
        {
            GameObject.Find("Game Canvas").GetComponent<TextBox>().ShowText(textFile);
            fov.IncreaseViewDistance(increaseFovAmount);
        }
        if(increaseTime)
        {
            FindObjectOfType<Clock>().IncreaseTimeRemaining(increaseTimeAmount);
        }

        Destroy(gameObject);
    }

   
}
