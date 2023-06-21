using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioClip song1;
    public AudioClip song2;
 
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicOn() {
        audioSource.clip = song1;
        audioSource.Play(0);
    }
    public void MusicOn2()
    {
        audioSource.clip = song2;
        audioSource.Play(0);
    }
    public void MusicOff()
    {
        audioSource.Pause();
    }

}
