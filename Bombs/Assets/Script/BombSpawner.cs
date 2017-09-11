using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {
    public Vector3[] BombSpawnPositions = new Vector3[9];
    GameObject Player;
    public GameObject BombPrefab;
    public float trackCooldown;
    int bombIndex;
    float time;
    bool wave;
    bool tracking;
	// Use this for initialization
	void Start () {
        wave = false;
        tracking = true;
        bombIndex = 0;
        Player = GameObject.Find("Player");
        InvokeRepeating("Switch", 5, 10);
        
       /* 
        foreach (Vector3 pos in BombSpawnPositions)
        {
            GameObject _bomb = Instantiate(BombPrefab, pos, Quaternion.identity);
        }
        */

    }
	
	// Update is called once per frame
	void Update () {
        if (trackCooldown > 0.3f)
            trackCooldown -= 0.01f * Time.deltaTime;
        if (wave)
            Wave();
        else if (tracking)
            Tracking();
        
		
	}
    void Wave()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            Instantiate(BombPrefab, BombSpawnPositions[bombIndex], Quaternion.identity);
            if(bombIndex>2)
                Instantiate(BombPrefab, BombSpawnPositions[bombIndex-3], Quaternion.identity);
            if (bombIndex < 8)
                bombIndex += 1;
            else
            {
                wave = false;
                tracking = true;
                bombIndex = 0;
            }
            time = 0;
        }
    }
    void Tracking()
    {
        time += Time.deltaTime;
        if (time >= trackCooldown)
        {
            Instantiate(BombPrefab,BombSpawnPositions[Player.GetComponent<PlayerScript>().index], Quaternion.identity);
            
          
            time = 0;
        }

    }
    void Switch()
    {
        tracking = false;
        wave = true;
    }
}
