using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBoxTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject answerInputUI;

    private int[] correctAnswer = { 9, 2, 4, 9 };
    private PlayerMovement playerMovement;
    public bool trueEndingUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        answerInputUI.SetActive(false);
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            answerInputUI.SetActive(true);
            Time.timeScale = 0;
            playerMovement.SetInputPermission(false);
        }
    }

    public void CloseAnswerBox()
    {
        answerInputUI.SetActive(false);
        Time.timeScale = 1;
        playerMovement.SetInputPermission(true);
    }

    public void AnswerEntered()
    {
        AnswerBoxHandle[] slots = answerInputUI.GetComponentsInChildren<AnswerBoxHandle>();

        bool isCorrect = true;
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetValue() != correctAnswer[slots[i].ID])
            {
                isCorrect = false;
            }
        }

        trueEndingUnlocked = isCorrect;

        //no longer allow input
        CloseAnswerBox();
        GameObject.FindGameObjectWithTag("LevelComplete").GetComponent<EndLevelHandle>().TrueEndingUnlocked();
        this.gameObject.SetActive(false);
    }
}
