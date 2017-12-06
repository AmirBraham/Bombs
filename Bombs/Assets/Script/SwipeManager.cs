using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour {
	Vector3 mousePosition;
	Vector2 fingerPosition;
	[SerializeField]
	Vector2 SwipeSensitivity;
	Vector2 dir;
	GameObject player;

    public void GetPlayer () {
        player = GameObject.FindGameObjectWithTag("Player");

    }

	void Update () {
        if (player != null)
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
                checkMobileSwipes();
            else
                checkComputerSwipes();
        }

		
	}
	void checkMobileSwipes (){
        
		dir = Vector2.zero;
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if(touch.phase==TouchPhase.Began){
				fingerPosition = touch.position;
				return;
			}
			if(touch.phase == TouchPhase.Ended){
				dir = touch.position - fingerPosition;
			}
			if(Mathf.Abs(dir.x)>SwipeSensitivity.x || Mathf.Abs(dir.y)>SwipeSensitivity.y){
				if(Mathf.Abs(dir.x)>Mathf.Abs(dir.y)){
					if (dir.x > 0) {
						player.GetComponent<PlayerScript> ().moveRight ();
					} else {
						player.GetComponent<PlayerScript> ().moveLeft ();
					}
				}else{
					if (dir.y > 0) {
						player.GetComponent<PlayerScript> ().moveUp ();
					} else {
						player.GetComponent<PlayerScript> ().moveDown();
					}
				}
			}
		}

	}
	void checkComputerSwipes (){
		dir = Vector2.zero;
		if (Input.GetMouseButtonDown(0)){
			mousePosition = Input.mousePosition;
			return;
		}
		if (Input.GetMouseButtonUp(0)){
			dir = Input.mousePosition - mousePosition;
		}
		if(Mathf.Abs(dir.x)>SwipeSensitivity.x || Mathf.Abs(dir.y)>SwipeSensitivity.y) {
			if(Mathf.Abs(dir.x)>Mathf.Abs(dir.y) ){
				if (dir.x > 0) {
					player.GetComponent<PlayerScript> ().moveRight ();
				} else {
					player.GetComponent<PlayerScript> ().moveLeft ();
				}
			} else {
				if (dir.y > 0) {
					player.GetComponent<PlayerScript> ().moveUp ();
				} else {
					player.GetComponent<PlayerScript> ().moveDown();
				}
			}

		}
	}
}
