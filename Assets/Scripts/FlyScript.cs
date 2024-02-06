using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script controlling behaviors of flies
//Fly disappears when ever the player's tongue collides with it

public class FlyScript : MonoBehaviour
{
    public GameController gameController; //access variables from GameController script

    //Fly movement
    public float moveSpeed = 5f;
    public Vector3 minPosition;
    public Vector3 maxPosition;

    void Start()
    {
        // Initialize fly's starting position
        transform.position = GetRandomPosition();
    }

    void Update()
    {
        // Move the fly randomly
        transform.position = Vector3.MoveTowards(transform.position, GetRandomPosition(), moveSpeed * Time.deltaTime);
    }

    Vector3 GetRandomPosition()
    {
        // Generate random position within the defined range
        float x = Random.Range(minPosition.x, maxPosition.x);
        float y = Random.Range(minPosition.y, maxPosition.y);
        float z = Random.Range(minPosition.z, maxPosition.z);

        return new Vector3(x, y, z);
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
