using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sgFeetSound : MonoBehaviour
{

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public void FeetSound()
    {
        if (audioClips == null)
            return;
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
    }
}
