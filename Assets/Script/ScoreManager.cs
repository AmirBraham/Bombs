using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour{
	
    public Text scoreBox;
    public int score;

	void Start(){
		InvokeRepeating ("IncrementRoutine", 1, 3);
	}

	public void Increment(int amount)
    {
		score += amount;
        scoreBox.text = score.ToString();
    }
	public void IncrementRoutine()
	{
		score += 1;
		scoreBox.text = score.ToString();
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
