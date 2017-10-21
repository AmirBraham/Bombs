using UnityEngine;
using DG.Tweening;


public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject[] UiItems;
    [SerializeField]
    GameObject CameraAnimator;
	// Use this for initialization
	void Start () {
        CameraAnimator.transform.DOMoveY(0, 3f).OnComplete(BringUI);
	}

    void BringUI () {
        foreach (GameObject ui in UiItems)
        {
            ui.transform.DOLocalMoveX(0f, 2f);
        }
    }
	
	// Update is called once per f

    public void StartGame () {
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().enabled = true;
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
    public void ToggleSound () {
        
    }
    public void RestartGame ( ) {
        foreach (GameObject ui in UiItems)
        {
            ui.transform.DOLocalMoveX(0f, 0.5f);
        }
    }
}
