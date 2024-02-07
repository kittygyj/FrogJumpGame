using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This script manages the music change
public class MusicChange : MonoBehaviour
{
    public LilyPadScript lilyPadScript;

    public AudioClip sinkMusic;
    private AudioSource currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        currentMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lilyPadScript.isSinked)
        {
            currentMusic.clip = sinkMusic;
        }
    }
}
