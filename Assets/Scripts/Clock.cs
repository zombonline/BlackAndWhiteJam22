using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] float maxTime, unlockedTime;
    [SerializeField] float timeRemaining;
    [SerializeField] Image unlockedTimeImage, clockArmImage;

    [SerializeField] Sprite[] clockTimes;
    private Image clockImage;

    private PlayerMovement playerMove;
    private void Awake()
    {
        //timeRemaining = unlockedTime;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        clockImage = GetComponent<Image>();

    }
    private void Update()
    {
        /*unlockedTimeImage.fillAmount = unlockedTime / maxTime;

        clockArmImage.rectTransform.eulerAngles = new Vector3(0, 0, -((timeRemaining / maxTime) * 360));*/

        if (timeRemaining <= 0)
        {
           playerMove.IsDefeated();
            clockImage.sprite = clockTimes[clockTimes.Length - 1];
        }
        else //calculate new index
        {
            int currIndex = Mathf.CeilToInt(timeRemaining / maxTime * clockTimes.Length - 1);
            clockImage.sprite = clockTimes[currIndex];
        }
        //update time remaining
        timeRemaining -= Time.deltaTime;
    }

    public void IncreaseUnlockedTime(float increaseValue)
    {
        unlockedTime += increaseValue;
        if(unlockedTime > maxTime)
        {
            unlockedTime = maxTime;
        }
    }

    public void IncreaseTimeRemaining(float increaseValue)
    {
        timeRemaining += increaseValue;
        if (timeRemaining > unlockedTime)
        {
            timeRemaining = unlockedTime;
        }
    }
}
