using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogShooting : MonoBehaviour
{
    public float fireDelay = 0.5f;

    public Vector3 tongueOffset = new Vector3(0, 0.5f, 0);

    public GameObject tonguePrefab;

    float cooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if ( Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("Pew!");
            cooldownTimer = fireDelay;

            //Fire!
            Vector3 offset = transform.rotation * tongueOffset;

            Instantiate(tonguePrefab, transform.position + offset, transform.rotation);
        }
    }
}
