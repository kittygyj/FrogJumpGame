using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    float rotSpeed = 180f;

    private enum FrogState { Idle, PrepareToJump, Jump }
    private FrogState currentState = FrogState.Idle;
    private float jumpHoldTime = 0f;

    private float maxJumpHoldTime = 2f;

    public bool isSink = false;


    void Start()
    {
        //
    }

    void Update()
    {
        Quaternion rot = transform.rotation;

        float z = rot.eulerAngles.z;

        z -= Input.GetAxis("Horizontal")*rotSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);

        transform.rotation = rot;

        switch (currentState)
        {
            case FrogState.Idle:
                // Check for jump input
                if (Input.GetButtonDown("Jump"))
                {
                    currentState = FrogState.PrepareToJump;
                    jumpHoldTime = 0f;
                }
                break;

            case FrogState.PrepareToJump:
                // Increment jump hold time
                jumpHoldTime += Time.deltaTime;

                // Check for releasing jump button
                if (Input.GetButtonUp("Jump"))
                {
                    Jump();
                    currentState = FrogState.Jump;
                }
                break;

            case FrogState.Jump:
                // Frog is jumping, do nothing until the jump is completed
                currentState = FrogState.Idle;
                break;
        }
    }

    void Jump()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, 5f * Mathf.Clamp(jumpHoldTime, 0f, maxJumpHoldTime), 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D lilyPad) 
    {
        if (lilyPad.gameObject.tag == "LilyPad")
        {
            isSink = false;
            Debug.Log("Safe");
        }
    }

    void OnTriggerExit2D(Collider2D lilyPad)
    {
        if (lilyPad.gameObject.tag == "LilyPad")
        {
            isSink = true;
            Debug.Log("danger");
        }
    }

}
