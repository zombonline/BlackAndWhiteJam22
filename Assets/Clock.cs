using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] float maxTime, unlockedTime;
    float timeRemaining;
    [SerializeField] Image unlockedTimeImage, clockArmImage;
    private void Awake()
    {
        timeRemaining = unlockedTime;
    }
    private void Update()
    {
        unlockedTimeImage.fillAmount = unlockedTime / maxTime;

        clockArmImage.rectTransform.eulerAngles = new Vector3(0, 0, -((timeRemaining / maxTime) * 360));

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
}
