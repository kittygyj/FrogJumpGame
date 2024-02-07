using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    public Toggle toggle1;
    public bool tongue_ez;

    public Toggle toggle2;

    public bool Levy_flight;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highscoreText.text = "HIGHSCORE: " + highScore.ToString();

        toggle1.onValueChanged.AddListener(delegate { ToggleValueChanged(toggle1); });
        tongue_ez = true;

        toggle2.onValueChanged.AddListener(delegate { ToggleValueChanged(toggle2); });
        Levy_flight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if(highScore < score)
        {
            highScore = score;
            highscoreText.text = "HIGHSCORE: " + highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
        }
    } 

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle == toggle1)
        {
            if (toggle.isOn)
            {
                // Enable one type of behavior
                tongue_ez = true;
                //Debug.Log("Toggle On!");
            }
            else
            {
                // Disable or change behavior
                tongue_ez = false;
                //Debug.Log("Toggle Off!");
            }
        }

        if (toggle == toggle2)
        {
            if (toggle.isOn)
            {
                // Enable one type of behavior
                Levy_flight = true;
                //Debug.Log("Toggle On!");
            }
            else
            {
                // Disable or change behavior
                Levy_flight = false;
                //Debug.Log("Toggle Off!");
            }
        }
        
        // Add additional conditions for more toggles
    }

}
