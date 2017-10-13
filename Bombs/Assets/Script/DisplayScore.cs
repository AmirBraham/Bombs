using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayScore : MonoBehaviour {
    public Text HighScoreText;
    public Text Score;
    public bool start;
	void Start () {
        HighScoreText.text = "High Score : " +PlayerPrefs.GetInt("HighScore", 0).ToString();
        if(!start) 
            Score.text = "Score : " + PlayerPrefs.GetInt("Score", 0).ToString();
        if(PlayerPrefs.GetInt("HighScore", 0) == PlayerPrefs.GetInt("Score", 0))
        {
            // Congratz you beat the High Score
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
