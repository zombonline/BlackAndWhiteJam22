using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] float maxTime, unlockedTime;
    float timeRemaining;
    [SerializeField] Image unlockedTimeImage, clockArmImage;

    private PlayerMovement playerMove;
    private void Awake()
    {
        timeRemaining = unlockedTime;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        unlockedTimeImage.fillAmount = unlockedTime / maxTime;

        clockArmImage.rectTransform.eulerAngles = new Vector3(0, 0, -((timeRemaining / maxTime) * 360));

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
           playerMove.IsDefeated();
        }
    }

    public void IncreaseUnlockedTime(float increaseValue)
    {
        unlockedTime += increaseValue;
        timeRemaining += increaseValue;
        if(unlockedTime > maxTime)
        {
            unlockedTime = maxTime;
        }
    }
}
