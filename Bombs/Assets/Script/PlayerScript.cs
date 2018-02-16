using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour {
	GameObject GameManager;
    public float lerpSpeed;
    public Vector3[] Positions = new Vector3[9];
    public int index;
    public Animator anim;
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
        index = 4;
        transform.position = Positions[index];
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, Positions[index], lerpSpeed * Time.deltaTime);
	}

	public void moveRight(){
        anim.StopPlayback();
        anim.Play("ballRR");
		if (index == 2 || index == 5)
			return;
		if (index <= 7)
			index += 1;
	}
	public void moveLeft(){
        anim.StopPlayback();
        anim.Play("ballRL");


		if (index == 3 || index == 6)
			return;
		if (index >= 1)
			index -= 1;

	}
	public void moveUp(){
        anim.StopPlayback();

        anim.Play("ballRU");

		if (index >= 3)
			index -= 3;

	}
	public void moveDown(){
        anim.StopPlayback();

        anim.Play("ballRD");

		if (index <= 5)
			index += 3;

	}



}
