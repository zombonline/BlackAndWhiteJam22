using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableHandle : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private Sprite unlockedSprite, lockedSprite;
    // Start is called before the first frame update
    void Start()
    {
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            CollectableId currId = buttons[i].GetComponent<CollectableId>();
            //check if collectable has been found
            if (PlayerPrefs.GetInt("Level " + currId.GetID().ToString()) > 0)
            {
                buttons[i].interactable = true;
                buttons[i].image.sprite = unlockedSprite;
                currId.HideSprite(false);
            }
            else
            {
                buttons[i].interactable = false;
                buttons[i].image.sprite = lockedSprite;
                currId.HideSprite(true);
            }
        }
    }
}
