using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreBox;
    public int score;

    public void Increment()
    {
        score += 1;
    }
    public void CheckHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                scoreBox.text = score.ToString() + "\n NEW RECORD";
                PlayerPrefs.SetInt("HighScore", score);
            }
            else
            {
                scoreBox.fontSize = 45;
                scoreBox.text = score.ToString();

            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
