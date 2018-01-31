using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class coinScript : MonoBehaviour {
	public int prize;
	float lifeTime = 3;
	BombSpawner bombSpawner;
	// Use this for initialization
	void Start () {
        transform.DOScale(new Vector3(1,1,1),2f);
		bombSpawner = GameObject.Find ("Spawner").GetComponent<BombSpawner> ();
		lifeTime = bombSpawner.spawnCoinTimer;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * 2);


		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0) {
			Destroy (gameObject);
		}
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().Increment(prize);
            transform.DOScale(new Vector3(0, 0, 0), 1f);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(gameObject,5f);
        }

    }
}
