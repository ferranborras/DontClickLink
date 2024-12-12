using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip correctSound;  
    public AudioClip incorrectSound;
    public AudioClip clickSound;  
    public AudioClip tapSound;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayIncorrectSound()
    {
        audioSource.PlayOneShot(incorrectSound);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayTapSound()
    {
        audioSource.PlayOneShot(tapSound);
    }
}
