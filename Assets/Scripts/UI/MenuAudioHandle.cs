using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioHandle : MonoBehaviour
{
    [SerializeField]
    private GameObject audioSources, backgroundMusicObject;
    private AudioSource mainClick, secondaryClick, hover, bgMusic;

    [SerializeField]
    private AudioClip stageMusic;

    // Start is called before the first frame update
    void Start()
    {
        //check if need to instansiate new audio sources
        if (!GameObject.FindGameObjectWithTag("MainClick"))
        {
            Instantiate(audioSources);
        }

        //check if backround music needs to be instansiated
        if (!GameObject.FindGameObjectWithTag("BackgroundMusic"))
        {
            Instantiate(backgroundMusicObject);
        }
        bgMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<AudioSource>();
        mainClick = GameObject.FindGameObjectWithTag("MainClick").GetComponent<AudioSource>();
        secondaryClick = GameObject.FindGameObjectWithTag("SecondaryClick").GetComponent<AudioSource>();
        hover = GameObject.FindGameObjectWithTag("ButtonHover").GetComponent<AudioSource>();

        //check background music is correct
        if (bgMusic.clip != stageMusic)
        {
            bgMusic.clip = stageMusic;
            bgMusic.Play();
        }
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
