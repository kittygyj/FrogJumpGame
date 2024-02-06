using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script controlling the lily pad
//lily pad disappears in 10 sec or so


public class LilyPadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //code here should be something like after xxxx secs, Destroy(gameObject)

        //I want to implement a music change here.
        //First, the lily pad stays on the water for a while
        //after some sec, it starts disappearing
        //should set a trigger here for music change
        //after the music changed, the lily pad stays for another few secs, and than destroy
        //The music change should ONLY happen when the player is on this lily pad. So maybe something like a collision detector should work here.

    }
}
