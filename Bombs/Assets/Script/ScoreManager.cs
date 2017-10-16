using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {
    public Text scoreBox;
    public int score;	

    public void Increment()
    {
        score += 1;
        scoreBox.text = score.ToString();
    }
    public void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetInt("Score", score);
    }
}
