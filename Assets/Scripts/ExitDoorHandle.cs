using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorHandle : MonoBehaviour
{
    private GameObject endLevel;

    private void Start()
    {
        endLevel = GameObject.FindGameObjectWithTag("LevelComplete");
        endLevel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            endLevel.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetInputPermission(false);
        }
    }
}
