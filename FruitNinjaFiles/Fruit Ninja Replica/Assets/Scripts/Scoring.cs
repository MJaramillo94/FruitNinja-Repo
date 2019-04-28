using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    public Text HighScore;
    private int HighestScore = 0;
    private void Start()
    {
        HighScore.text = "Current Highscore: " + PlayerPrefs.GetInt("Current Highscore: ", 0).ToString();
    }

    private void Update()
    {
        if(Blade.count > PlayerPrefs.GetInt("Current Highscore: ", 0))
        {
            HighestScore = Blade.count;
            PlayerPrefs.SetInt("Current Highscore: ", HighestScore);
            HighScore.text = "Current High Score: " + HighestScore.ToString(); ;
        }
    }
}
