using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class coinScript : MonoBehaviour {
    public int prize;
    float lifeTime = 3;
    BombSpawner bombSpawner;
    public GameObject ScoreAnimation;
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
            GameObject scoreAnim = Instantiate(ScoreAnimation, new Vector3(240,0,0), Quaternion.identity);
            scoreAnim.transform.parent = GameObject.FindGameObjectWithTag("canvas").transform;
            Destroy(gameObject,5f);
        }

        if(PlayerPrefs.HasKey("money")) {
            PlayerPrefs.SetInt("money",PlayerPrefs.GetInt("money")+1);
        } else {
            PlayerPrefs.SetInt("money",1);
        }

    }
}
