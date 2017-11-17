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

    // Update is called once per f
    void Update()
    {
    }
    public void StartGame () {
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().enabled = true;
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().Dead = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().enabled = true;
        foreach(GameObject ui in UiItems) {
            ui.transform.DOLocalMoveX(500f, 2f);
        }
    }
    public void ChooseLevel () {
        //ADD MORE LEVELS and Modifications 
    }
    public void SeeScoreBoard () {
        //ADD SCOREBOARD
    }
    public void SeeSettings  () {
        
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
    }
}
