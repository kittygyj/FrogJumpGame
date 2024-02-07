using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script controlling behaviors of flies
//Fly disappears when ever the player's tongue collides with it

public class FlyScript : MonoBehaviour
{
    public GameController gameController; //access variables from GameController script

    //Fly movement
    public float moveSpeed = 2f;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public float levyAlpha = 2f; // Parameter for the Levy distribution


    void Start()
    {
        // Initialize fly's starting position
        transform.position = GetRandomPosition();
    }

    void Update()
    {
        transform.position = GetRandomPositionLevy();

        bool Levy_flight = ScoreManager.instance.Levy_flight;

        if(Levy_flight)
        {
            //transform.position = GetRandomPositionLevy();
        }
        
    }

    Vector3 GetRandomPosition()
    {
        // Generate random position within the defined range
        float x = Random.Range(minPosition.x, maxPosition.x);
        float y = Random.Range(minPosition.y, maxPosition.y);
        float z = Random.Range(minPosition.z, maxPosition.z);

        return new Vector3(x, y, z);
    }

    Vector3 GetRandomPositionLevy()
    {
        // Generate random step sizes according to the Levy distribution
        float stepLength = LevyDistribution(levyAlpha) * moveSpeed;
        // Generate random direction
        float angle = Random.Range(0f, Mathf.PI * 2); // Random angle in radians
        // Calculate the new position based on the random step size and direction
        Vector3 newPosition = transform.position + new Vector3(Mathf.Cos(angle) * stepLength, Mathf.Sin(angle) * stepLength, 0f);
        // Clamp the new position within the defined range
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
        newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);

        return newPosition;
    }

    // Levy distribution function
    float LevyDistribution(float alpha)
    {
        // Generate a random step size according to the Levy distribution
        float u = Random.Range(0.0001f, 0.9999f); // Avoiding 0 and 1 for stability
        float v = Random.Range(0.0001f, 0.9999f); // Avoiding 0 and 1 for stability
        float step = Mathf.Pow((1 / Mathf.Cos(v)), (1 / alpha)) * Mathf.Sin(alpha * u) / Mathf.Pow(u, (1 / alpha));

        return step;
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

    //Fly only collides with tongue
    //The reason why i create tongue layer and frog layer separately is , frog collides with lilypads, tongue collides with flies, but tongue should not collides with lilypads.
    //If the tongue is tagged with "Player", then lilypads that is touched by tongue will sink.
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        Die();
    }

    void Die()
    {
        Debug.Log("Score!");
        ScoreManager.instance.AddPoint();
        //gameController.score =+1 ; //adding score when the player catches a fly
        Destroy(gameObject); //make the fly object disappear on the screen
    }

}
