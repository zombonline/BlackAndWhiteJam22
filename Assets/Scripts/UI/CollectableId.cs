using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableId : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private Image collectableSprite;
    private void Start()
    {
        //collectableSprite = GetComponentInChildren<Image>();
    }

    public int GetID()
    {
        return level;
    }

    public void HideSprite(bool hide)
    {
        if (hide){
            collectableSprite.color = new Color(1, 1, 1, 0);
        }
        else
        {
            collectableSprite.color = new Color(1, 1, 1, 1);
        }
    }
}
