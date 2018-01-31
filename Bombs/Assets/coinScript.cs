using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class coinScript : MonoBehaviour {
	public float lifeTime = 3;
	// Use this for initialization
	void Start () {
        transform.DOScale(new Vector3(1,1,1),2f);
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
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>().Increment(1);
            transform.DOScale(new Vector3(0, 0, 0), 1f);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(gameObject,5f);
        }

    }
}
