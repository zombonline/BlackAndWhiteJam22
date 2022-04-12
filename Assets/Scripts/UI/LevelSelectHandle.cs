using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectHandle : MonoBehaviour
{
    [SerializeField]
    private Button levelButton;
    [SerializeField]
    private Sprite lockedSprite, checkBoxChecked, checkBoxUnchecked;

    [SerializeField]
    private int[] levelsInStages = new int[5];

    [SerializeField]
    private GameObject[] worlds = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        LoadLevels();
    }

    private void LoadLevels()
    {
        int numStages = levelsInStages.Length;

        for (int i = 0; i < numStages; i++)
        {

            for (int j = 0; j < levelsInStages[i]; j++)
            {

                Button currButton = Instantiate(levelButton);
                currButton.transform.SetParent(worlds[i].transform);
                currButton.transform.localScale = new Vector3(1, 1, 1);
                currButton.GetComponent<LevelButtonId>().SetID(new LevelButtonId.LevelID(i + 1, j + 1));

                //check for collectable
                if (PlayerPrefs.HasKey("Level " + ((i * 10) + (j + 1))))
                {
                    var collectableImage = currButton.transform.Find("Collectable").GetComponent<Image>();
                    collectableImage.enabled = true;
                    if(PlayerPrefs.GetInt("Level " + ((i * 10) + (j + 1))) > 0)
                    {
                        collectableImage.sprite = checkBoxChecked;
                    }
                    else
                    {
                        collectableImage.sprite = checkBoxUnchecked;
                    }

                }
                //check if is unlocked
                if ((i * 10) + (j + 1) > PlayerPrefs.GetInt("LevelsUnlocked"))
                {
                    currButton.GetComponent<Image>().sprite = lockedSprite;
                    currButton.interactable = false;
                }
                
            }
        }
    }

    public void UnlockAll()
    {
        PlayerPrefs.SetInt("LevelsUnlocked", 100);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //hard coded creation of playerprefs for collectables
        if(!PlayerPrefs.HasKey("Level 3"))
        {
            PlayerPrefs.SetInt("Level 3", 0);
        }

        if (!PlayerPrefs.HasKey("Level 5"))
        {
            PlayerPrefs.SetInt("Level 5", 0);
        }

        if (!PlayerPrefs.HasKey("Level 6"))
        {
            PlayerPrefs.SetInt("Level 6", 0);
        }

        if (!PlayerPrefs.HasKey("Level 7"))
        {
            PlayerPrefs.SetInt("Level 7", 0);
        }

        if (!PlayerPrefs.HasKey("Level 8"))
        {
            PlayerPrefs.SetInt("Level 8", 0);
        }

        if (!PlayerPrefs.HasKey("Level 9"))
        {
            PlayerPrefs.SetInt("Level 9", 0);
        }
        //world 2
        if (!PlayerPrefs.HasKey("Level 12"))
        {
            PlayerPrefs.SetInt("Level 12", 0);
        }

        if (!PlayerPrefs.HasKey("Level 13"))
        {
            PlayerPrefs.SetInt("Level 13", 0);
        }

        if (!PlayerPrefs.HasKey("Level 14"))
        {
            PlayerPrefs.SetInt("Level 14", 0);
        }

        if (!PlayerPrefs.HasKey("Level 17"))
        {
            PlayerPrefs.SetInt("Level 17", 0);
        }

        if (!PlayerPrefs.HasKey("Level 18"))
        {
            PlayerPrefs.SetInt("Level 18", 0);
        }

        if (!PlayerPrefs.HasKey("Level 19"))
        {
            PlayerPrefs.SetInt("Level 19", 0);
        }
        //world 3
        if (!PlayerPrefs.HasKey("Level 22"))
        {
            PlayerPrefs.SetInt("Level 22", 0);
        }

        if (!PlayerPrefs.HasKey("Level 23"))
        {
            PlayerPrefs.SetInt("Level 23", 0);
        }

        if (!PlayerPrefs.HasKey("Level 24"))
        {
            PlayerPrefs.SetInt("Level 24", 0);
        }

        if (!PlayerPrefs.HasKey("Level 26"))
        {
            PlayerPrefs.SetInt("Level 26", 0);
        }

        if (!PlayerPrefs.HasKey("Level 27"))
        {
            PlayerPrefs.SetInt("Level 27", 0);
        }

        if (!PlayerPrefs.HasKey("Level 29"))
        {
            PlayerPrefs.SetInt("Level 29", 0);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
