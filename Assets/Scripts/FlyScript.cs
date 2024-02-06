using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script controlling behaviors of flies
//Fly disappears when ever the player's tongue collides with it

public class FlyScript : MonoBehaviour
{
    public GameController gameController; //access variables from GameController script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //code for checking if the player's tongue collides the fly
    //if you are making a tongue object for the player, don't forget to tag it with "Player" tag

    void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.score =+1 ; //adding score when the player catches a fly
            Destroy(gameObject); //make the fly object disappear on the screen
        }

    }

}
