using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandle : MonoBehaviour
{

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
