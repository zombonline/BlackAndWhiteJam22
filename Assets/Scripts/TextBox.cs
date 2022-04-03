using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] Image textBox;
    [SerializeField] TextMeshProUGUI textComponent;

    public void ShowText(TextAsset textFile)
    {
        textBox.gameObject.SetActive(true);
        StartCoroutine(TypeWriterText(textFile));
    }

    IEnumerator TypeWriterText(TextAsset textFile)
    {
        for (int i = 0; i <= textFile.text.Length; i++)
        {
            yield return new WaitForSeconds(0.01f);
            textComponent.text = textFile.text.Substring(0, i);
        }
    }

    public void OkButton()
    {
        textBox.gameObject.SetActive(false);
        textComponent.text = null;
    }
}
