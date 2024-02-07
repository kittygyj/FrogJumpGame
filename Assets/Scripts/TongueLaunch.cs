using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueLaunch : MonoBehaviour
{

    public float maxTongueLengthMultiplier = 5f;
    public float tongueStretrchDuration  = 0.5f;

    public float tongueShrinkDuration = 0.2f;
    float currentTongueLength;

    float initialTongueLength;

    float maxTongueLength;
    float startTime;

    //float epsilon = 0.001f;

    float EaseInOut(float t)
    {
        return t < 0.5f ? 2f * t * t : -1f + (4f - 2f * t) * t;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Tongue Start!");
        
        initialTongueLength = transform.localScale.y;

        currentTongueLength = initialTongueLength;
        maxTongueLength = initialTongueLength * maxTongueLengthMultiplier;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        if(elapsedTime < tongueStretrchDuration)
        {
            float ratio = Mathf.Min(elapsedTime/tongueStretrchDuration, 1f);

            ratio = EaseInOut(ratio);

            currentTongueLength = ratio*maxTongueLength;
        } else 
        {
            float ratio = Mathf.Min((elapsedTime-tongueStretrchDuration)/tongueShrinkDuration, 1f);

            //ratio = EaseInOut(ratio);

            currentTongueLength = (1f-ratio)*maxTongueLength;
        }
        

        // Update the tongue's scale based on the current length
        transform.localScale = new Vector3(transform.localScale.x, currentTongueLength, 1f);

        if(elapsedTime > tongueStretrchDuration + tongueShrinkDuration)
        {
            Die();
        }

        return;
    }

    void Die()
    {
        //Debug.Log("Tongue Die!");
        Destroy(gameObject);
    }
}
