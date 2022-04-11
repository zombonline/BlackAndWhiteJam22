using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorHandle : MonoBehaviour
{
    private GameObject endLevel;
    [SerializeField] GameObject parent;

    private void Start()
    {
        endLevel = GameObject.FindGameObjectWithTag("LevelComplete");
        endLevel.SetActive(false);
    }

    private void Update()
    {
        parent.transform.Rotate(0,0,Time.deltaTime * 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            endLevel.SetActive(true);
            endLevel.GetComponent<EndLevelHandle>().PlayFinishSound();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetInputPermission(false);

            //check for level unlock update
            if (PlayerPrefs.GetInt("LevelsUnlocked") <= SceneManager.GetActiveScene().buildIndex)
            {
                PlayerPrefs.SetInt("LevelsUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

}
