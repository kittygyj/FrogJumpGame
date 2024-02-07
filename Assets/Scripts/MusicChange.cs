using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This script manages the music change
public class MusicChange : MonoBehaviour
{
    public GameObject player;
    private FrogMovement playerScript;

    public AudioClip sinkMusic;
    private AudioSource currentMusic;

    // Start is called before the first frame update
    void Start()
    {
        currentMusic = GetComponent<AudioSource>();
        playerScript = player.GetComponent<FrogMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isSink)
        {
            currentMusic.clip = sinkMusic;
        }
    }
}
