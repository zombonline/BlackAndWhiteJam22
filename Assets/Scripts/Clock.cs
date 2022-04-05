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
    [SerializeField] Image warningImage;
    private Image clockImage;

    private int currIndex;
    private bool isWarning = false;

    private PlayerMovement playerMove;
    private void Awake()
    {
        //timeRemaining = unlockedTime;
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        clockImage = GetComponent<Image>();

        warningImage.color = new Color(1, 1, 1, 0);

    }
    private void Update()
    {
        /*unlockedTimeImage.fillAmount = unlockedTime / maxTime;

        clockArmImage.rectTransform.eulerAngles = new Vector3(0, 0, -((timeRemaining / maxTime) * 360));*/

        if (timeRemaining <= 0)
        {
           playerMove.IsDefeated();
            ToggleWarning(false);
            clockImage.sprite = clockTimes[clockTimes.Length - 1];
        }
        else //calculate new index
        {
            currIndex = Mathf.CeilToInt(timeRemaining / maxTime * clockTimes.Length - 1);
            clockImage.sprite = clockTimes[currIndex];

            isWarning = currIndex == 0 ? true : false;
            ToggleWarning(isWarning);
        }

        if (isWarning)
        {
            warningImage.rectTransform.Rotate(new Vector3(0, 0, 1), 300 * Time.deltaTime);
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

    private void ToggleWarning(bool tog)
    {
        if (tog)
        {
            warningImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            warningImage.transform.rotation = Quaternion.Euler(Vector3.zero);
            warningImage.color = new Color(1, 1, 1, 0);
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
