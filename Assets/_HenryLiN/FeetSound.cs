using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        if (audioClips == null)
            return;
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length) + 1]);
    }
}
