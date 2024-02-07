using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script controlling the lily pad
//lily pad disappears in 10 sec or so


public class LilyPadScript : MonoBehaviour
{
    public float timeBeforeDisappear = 5f;
    //public AudioClip musicClip; // Assign the music clip in the Unity Editor
    private bool hasPlayerEntered = false;
    //private AudioSource audioSource;
    private float startTime;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (hasPlayerEntered)
        {
            // If the player has entered the lily pad trigger, start counting time
            float elapsedTime = Time.time - startTime;
    
            // If enough time has passed, trigger the music change and destroy the lily pad
            if (elapsedTime >= timeBeforeDisappear)
            {
                //ChangeMusic();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(hasPlayerEntered == false)
        {
            hasPlayerEntered = true;
            startTime = Time.time;
        }
        
    }

    // void ChangeMusic()
    // {
    //     // Check if an audio clip is assigned
    //     if (musicClip != null)
    //     {
    //         // Change the music to the assigned clip
    //         audioSource.clip = musicClip;
    //         audioSource.Play();
    //     }
    // }
}
