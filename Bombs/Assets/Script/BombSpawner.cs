using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {
    public Vector3[] BombSpawnPositions = new Vector3[9];
    GameObject Player;
    public GameObject BombPrefab;
    public float trackCooldown;
    [SerializeField]
    int bombIndex;
    float time;
    int step;
    int delay;
    float cd;
    bool tracking;
   
    
  
	// Use this for initialization
	void Start () {
        tracking = true ;
        bombIndex = 0;
        Player = GameObject.Find("Player");
        InvokeRepeating("Switch", 5, 10);
        

    }

  
    private void Update()
    {
        if(trackCooldown >=0.5f)
            trackCooldown -= Time.deltaTime * 0.01f;
        if (!tracking)
            Universal(step, cd,delay);
        else if (tracking)
            Tracking();
            
            

           

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
        tracking = !tracking;
        step = Random.Range(1, 4);
        delay = Random.Range(-4, 4);
        cd = Random.Range(0.7f, 0.2f);
        if (tracking == false)
            Debug.Log("step: " + step + "delay: " + delay);
        
    }
    
    
    void Universal( int step, float cd,int delay = 0)
    {
        
        
            time += Time.deltaTime;
            if (time >= cd)
            {
               
                Instantiate(BombPrefab, BombSpawnPositions[bombIndex], Quaternion.identity);
            if (delay != 0)
            {
                if (bombIndex >= delay && (bombIndex - delay) < 9)
                    
                    Instantiate(BombPrefab, BombSpawnPositions[bombIndex - delay], Quaternion.identity);
            }
            if (bombIndex < 9 - step)
                    bombIndex += step;
                else if (bombIndex >= 9 - step)
                {
                bombIndex = 0;
                tracking = true;
                }
                time = 0;
            }

        
    }
}
