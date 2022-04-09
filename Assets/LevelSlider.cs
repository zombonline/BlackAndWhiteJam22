using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    private float pageDistance = 1000;
    private float minXValue = -4000;
    private float maxXValue = 0;

    public Button leftButton, rightButton;

    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        leftButton.interactable = false;
    }

    public void SlideLeft()
    {
        if (rect.anchoredPosition.x < maxXValue)
        {
            rect.anchoredPosition += new Vector2(pageDistance, 0);
        }

        if (rect.anchoredPosition.x >= maxXValue)
        {
            leftButton.interactable = false;
        }
        if (rect.anchoredPosition.x > minXValue)
        {
            rightButton.interactable = true;
        }
    }

    public void SlideRight()
    {
        if (rect.anchoredPosition.x > minXValue)
        {
            rect.anchoredPosition += new Vector2(-pageDistance, 0);
        }

        if (rect.anchoredPosition.x <= minXValue)
        {
            rightButton.interactable = false;
        }
        if (rect.anchoredPosition.x < maxXValue)
        {
            leftButton.interactable = true;
        }
    }
}
