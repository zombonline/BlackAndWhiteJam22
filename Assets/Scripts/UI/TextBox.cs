using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] Image textBox;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] TextAsset sceneText;
    private PlayerMovement playerMovement;
    private AudioSource audioSource;
    private bool typing, boxOpen, skipText;
    [SerializeField] bool isInGame;
    private void Start()
    {
        if (!isInGame)
        {
            audioSource = GetComponent<AudioSource>();
            if (sceneText != null)
            {
                ShowText(sceneText);
            }
        }
        else
        {
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && boxOpen)
        {
            if (typing)
            {
                skipText = true;
            }
            else
            {
                if (sceneText != null)
                {
                    GameObject.Find("Canvas").GetComponent<EndGameHandle>().BeginFromStart();
                }
                OkButton();
            }
        }
    }

    public void ShowText(TextAsset textFile)
    {
        if (playerMovement != null)
        {
            playerMovement.SetInputPermission(false);
        }
        Time.timeScale = 0;
        boxOpen = true;
        textBox.gameObject.SetActive(true);
        StartCoroutine(TypeWriterText(textFile));
    }

    IEnumerator TypeWriterText(TextAsset textFile)
    {
        if (!typing)
        {
            typing = true;
            audioSource.Play();
            for (int i = 0; i <= textFile.text.Length; i++)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                textComponent.text = textFile.text.Substring(0, i);

                if (skipText)
                {
                    textComponent.text = textFile.text;
                    break;
                }
            }
            audioSource.Stop();
            typing = false;
            skipText = false;
        }


    }

    public void OkButton()
    {
        audioSource.Stop();
        if (typing)
        {
            skipText = true;
        }
        
        if (isInGame)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSound>().PlayVisionUpSound();
        }
        
        textBox.gameObject.SetActive(false);
        textComponent.text = null;
        boxOpen = false;
        Time.timeScale = 1;
        if (playerMovement != null)
        {
            playerMovement.SetInputPermission(true);
        }
    }
}
