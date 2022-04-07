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

    // Start is called before the first frame update
    void Start()
    {
        currLevel = SceneManager.GetActiveScene().buildIndex;
        text.text = "Level - " + currLevel + "\nCompleted";
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
