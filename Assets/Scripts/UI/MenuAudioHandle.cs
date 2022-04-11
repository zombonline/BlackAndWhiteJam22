using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject audioSources;
    private AudioSource mainClick, secondaryClick, hover;

    // Start is called before the first frame update
    void Start()
    {
        //check if need to instansiate new audio sources
        if (!GameObject.FindGameObjectWithTag("MainClick"))
        {
            Instantiate(audioSources);
        }

        mainClick = GameObject.FindGameObjectWithTag("MainClick").GetComponent<AudioSource>();
        secondaryClick = GameObject.FindGameObjectWithTag("SecondaryClick").GetComponent<AudioSource>();
        hover = GameObject.FindGameObjectWithTag("ButtonHover").GetComponent<AudioSource>();
    }

    public void PlayMainClick()
    {
        mainClick.Play();
    }
    public void PlaySecondaryClick()
    {
        secondaryClick.Play();
    }
    public void PlayButtonHover()
    {
        hover.Play();
    }
}
