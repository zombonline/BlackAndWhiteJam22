using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBoxHandle : MonoBehaviour
{
    [SerializeField]
    private Sprite[] numberSprites;
    public int ID;

    private int currValue = 0;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public int GetValue()
    {
        return currValue;
    }

    private void UpdateSprite()
    {
        image.sprite = numberSprites[currValue];
    }

    public void Increase()
    {
        if (currValue == 9)
        {
            currValue = 0;
        }
        else
        {
            currValue++;
        }
        UpdateSprite();
    }

    public void Decrease()
    {
        if (currValue == 0)
        {
            currValue = 9;
        }
        else
        {
            currValue--;
        }
        UpdateSprite();
    }
}
