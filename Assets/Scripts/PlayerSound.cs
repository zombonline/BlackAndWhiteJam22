using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip defeatSound, buttonSound, visionUpSound, collectableSound;

    [SerializeField]
    private AudioClip[] stepSounds, clockSounds, doorSounds;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStepSound()
    {
        audioSource.PlayOneShot(stepSounds[Random.Range(0, stepSounds.Length - 1)]);
    }

    public void PlayDefeatSound()
    {
        audioSource.PlayOneShot(defeatSound);
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
        PlayDoorSound();
    }

    public void PlayDoorSound()
    {
        audioSource.PlayOneShot(doorSounds[Random.Range(0, doorSounds.Length - 1)]);
    }

    public void PlayClockSound(float increaseAmount)
    {
        int clipIndex = 0;

        if (increaseAmount > 3)
        {
            if (increaseAmount > 7)
            {
                clipIndex = 2;
            }
            else
            {
                clipIndex = 1;
            }
        }

        audioSource.PlayOneShot(clockSounds[clipIndex]);
    }

    public void PlayCollectableSound()
    {
        audioSource.PlayOneShot(collectableSound);
    }

    public void PlayVisionUpSound()
    {
        audioSource.PlayOneShot(visionUpSound);
    }
}
