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
    private Sprite lockedSprite;

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

                //check if is unlocked
                if (PlayerPrefs.HasKey("Level " + ((i * 10) + (j + 1))))
                {
                    var collectableText = currButton.transform.Find("Collectable").GetComponent<TextMeshProUGUI>();
                    collectableText.enabled = true;
                    collectableText.text = PlayerPrefs.GetInt("Level " + ((i * 10) + (j + 1))) + "/1";
                }

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
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
