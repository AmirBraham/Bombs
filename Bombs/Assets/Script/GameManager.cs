using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject[] UiItems;
    [SerializeField]
    GameObject CameraAnimator;
    [SerializeField]
    Sprite[] SoundIcons;
    [SerializeField]
    AudioSource Audio;
    [SerializeField]
    GameObject scoreText;
    [SerializeField]
    GameObject[] ScoreUI;
    // Use this for initialization
	void Start () {
        Audio.PlayDelayed(2f);
        CameraAnimator.transform.DOMoveY(0, 3f).OnComplete(BringUI);
	}

    void BringUI () {
        foreach (GameObject ui in UiItems)
        {
            ui.transform.DOLocalMoveX(0f, 2f);
        }
    }
    public void StartGame () {
        GetComponent<ScoreManager>().score = 0;
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().enabled = true;
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().Dead = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().enabled = true;
        foreach(GameObject ui in UiItems) {
            ui.transform.DOLocalMoveX(500f, 2f);
        }  
        scoreText.transform.DOLocalMoveX(0f, 2f);
        scoreText.GetComponent<Text>().fontSize = 18;
        scoreText.GetComponent<Text>().text = "0";
        ScoreUI[0].transform.DOLocalMoveX(260f, 0.5f);
        ScoreUI[1].transform.DOLocalMoveX(260f, 0.5f);
    }
    public void Rate () {
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=YOUR_ID");
        #elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
        #endif
    }
    public void Levels () {
        for (int i = 0; i < UiItems.Length;i++ ) {
            if(i != 3) 
                UiItems[i].transform.DOLocalMoveX(500f, 1f);
        }
        UiItems[3].transform.DOLocalMoveY(0f, 1.5f);
        UiItems[3].transform.GetChild(0).gameObject.GetComponent<shopNavigator>().updatemoney();
    }
    public void Settings  () {
        
    }
    public void ToggleSound (Button button) {
        Debug.Log(button.name);
        if(button.GetComponent<Image>().sprite.name == "mute") {
            button.GetComponent<Image>().sprite = SoundIcons[0];
            Audio.mute = false;
        } else {
            button.GetComponent<Image>().sprite = SoundIcons[1];
            Audio.mute = true;
        }
    }
    public void RestartGame ( ) {
        foreach (GameObject ui in UiItems)
        {
            ui.transform.DOLocalMoveX(0f, 0.5f);
        }
        scoreText.transform.DOLocalMoveX(130f, 2f);
        ScoreUI[0].transform.DOLocalMoveX(0f, 0.5f);
        ScoreUI[1].transform.DOLocalMoveX(0f, 0.5f);
        ScoreUI[0].GetComponent<Text>().text = "Current score : " + scoreText.GetComponent<Text>().text;
        ScoreUI[1].GetComponent<Text>().text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void QuitShop()
    {
        Debug.Log("clicked");
        for (int i = 0; i < UiItems.Length; i++)
        {
            if (i != 3)
                UiItems[i].transform.DOLocalMoveX(0f, 2f);
        }
        UiItems[3].transform.DOLocalMoveY(500f, 1f);
    }
}
