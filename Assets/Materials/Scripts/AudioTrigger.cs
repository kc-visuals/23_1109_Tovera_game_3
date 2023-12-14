using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
   

    void OnTriggerEnter(Collider other)
    {
        // Checks if object colliding has player tag
        if (other.CompareTag("Player"))
        {
            //Plays when player enters trigger
            PlayAudio();
        }
    }

    void PlayAudio()
    {
        // Checks if audio source is assigned
        if (audioSource != null)
        {
            //Plays audio
            audioSource.Play();
        }
    }
}
