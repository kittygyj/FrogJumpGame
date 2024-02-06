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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Generating lily pad and fly randomly on the screen should happen here.
        //Generation should happen when total number of lily pad and fly is smaller than a certain number
        //See the Unity API for Instantiate()
    }
}
