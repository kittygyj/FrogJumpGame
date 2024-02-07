using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the script for controlling randomly instantiate lily pad and fly prefabs on the screen
//And also the UI showing scores, this comes later

public class GameController : MonoBehaviour
{
    public GameObject lilyPad;
    public GameObject fly;

    public int score; //an empty variable for score, should be used for the showing score UIs later

    //get the width and height of the screen. this is used for instantiating the prefabs
    public float width = Screen.width;
    public float height = Screen.height;

    
    // Update is called once per frame
    void Update()
    {
        //Generating lily pad and fly randomly on the screen should happen here.
        //Generation should happen when total number of lily pad and fly is smaller than a certain number
        //See the Unity API for Instantiate()
    }

    public GameObject lilyPadPrefab;
    public GameObject flyPrefab;
    public Vector2 lilyPadSpawnArea;
    public Vector2 flySpawnArea;
    public float lilyPadSpawnInterval = 5f;
    public float flySpawnInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Start spawning lily pads and flies
        //StartCoroutine(SpawnLilyPads());
        StartCoroutine(SpawnFlies());
    }

    IEnumerator SpawnLilyPads()
    {
        while (true)
        {
            // Instantiate lily pad at a random position within the spawn area
            Vector3 spawnPosition = new Vector3(Random.Range(lilyPadSpawnArea.x, lilyPadSpawnArea.y), 0f, Random.Range(lilyPadSpawnArea.x, lilyPadSpawnArea.y));
            Instantiate(lilyPadPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified interval before spawning the next lily pad
            yield return new WaitForSeconds(lilyPadSpawnInterval);
        }
    }

    IEnumerator SpawnFlies()
    {
        while (true)
        {
            // Instantiate fly at a random position within the spawn area
            Vector3 spawnPosition = new Vector3(Random.Range(flySpawnArea.x, flySpawnArea.y), 0f, Random.Range(flySpawnArea.x, flySpawnArea.y));
            Instantiate(flyPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified interval before spawning the next fly
            yield return new WaitForSeconds(flySpawnInterval);
        }
    }
}
