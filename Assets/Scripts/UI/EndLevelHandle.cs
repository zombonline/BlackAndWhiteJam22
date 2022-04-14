using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelHandle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private int currLevel;

    private bool trueEnding = false;

    // Start is called before the first frame update
    void Start()
    {
        currLevel = SceneManager.GetActiveScene().buildIndex;
        if (currLevel <= 30)
        {
            text.text = "Level - " + currLevel + "\nCompleted";
        }
        else
        {
            text.text = "CYCLE COMPLETED";
        }
        
    }

    private void Update()
    {
        if (this.gameObject.activeInHierarchy && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            NextLevel();
        }
    }


    public void NextLevel()
    {
        if (trueEnding)
        {
            SceneManager.LoadScene("TrueEnding");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayFinishSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void TrueEndingUnlocked()
    {
        trueEnding = true;
    }
}
