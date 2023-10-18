using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool playMusic=false;

    public void PlayAudio()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //set the source to be the object's audio source
        audioSource = GetComponent<AudioSource>();
    }
}
