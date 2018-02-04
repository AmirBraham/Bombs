using UnityEngine;
using System.Collections;
public class BombSpawner : MonoBehaviour
{
	public const float BombTimer = 5;
	public const float TrackTimer = 1;
	public const float CoinTimer = 3;
    public const float ShieldTimer = 9;
    public Vector3[] BombSpawnPositions = new Vector3[9];
	public GameObject coin;
    public GameObject shield;
    GameObject Player;
    public bool Dead;
    public GameObject BombPrefab;
	Vector3 finalSpawnpos;
    int spawnLimit = 7;
	public float bombSpawnTimer;
	public float trackPlayerTimer;
	public float spawnCoinTimer;
    public float shieldTimer;
	float bSTimer;
	float tPTimer;
	float sCTimer;
    float sHTimer;
    void Start()
    {
		resetTimer ();
    }
	void Update(){
		Player = GameObject.FindGameObjectWithTag ("Player");

		bSTimer += Time.deltaTime;
		tPTimer += Time.deltaTime;
		sCTimer += Time.deltaTime;
        sHTimer += Time.deltaTime;

		if (bSTimer >= bombSpawnTimer) {
			spawnPattern ();
			bSTimer = 0;
		}
		if (tPTimer >= trackPlayerTimer) {
			trackPlayer ();
			tPTimer = 0;
		}
		if (sCTimer >= spawnCoinTimer) {
			spawnCoin ();
			sCTimer = 0;
		}
        if (sHTimer >= shieldTimer)
        {
            spawnShield();
            sHTimer = 0;
        }



		if (bombSpawnTimer >= 2)
			bombSpawnTimer -= 0.02f * Time.deltaTime;
		if (trackPlayerTimer >= 0.5f)
			trackPlayerTimer -= 0.02f * Time.deltaTime;
		if (spawnCoinTimer >= 2)
			spawnCoinTimer -= 0.02f * Time.deltaTime;
        if (shieldTimer >= 2)
            shieldTimer -= 0.02f * Time.deltaTime;
	}



	void spawnCoin(){
		int n = Random.Range (1, 4);
		int playerpos = Player.GetComponent<PlayerScript> ().index;
		while (n > 0) {
			int p = Random.Range (0, 8);
			while (p == playerpos) {
				p = Random.Range (0, 8);
			}
			Instantiate (coin, Player.GetComponent<PlayerScript> ().Positions [p], Quaternion.identity);
			n--;
				
		}
	
	}
    void spawnShield()
    {
        int playerpos = Player.GetComponent<PlayerScript>().index;
        int p = Random.Range(0, 8);
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
        for (int i = 0; i < coins.Length;i++) {
            if(coins[i].transform.position == Player.GetComponent<PlayerScript>().Positions[p] ) {
                p = Random.Range(0, 8);
            }
        }

        Instantiate(shield, Player.GetComponent<PlayerScript>().Positions[p], Quaternion.identity);

    }
    void spawnPattern()
    {
        if (!Dead)
        {
            int[] randomSkippedBombs = { (int)Random.Range(0, spawnLimit), (int)Random.Range(0, spawnLimit) };
            for (int i = 0; i < spawnLimit; i++)
            {
                if (!(randomSkippedBombs[0] == i || randomSkippedBombs[1] == i))
                {
					finalSpawnpos.x = BombSpawnPositions [i].x;
					finalSpawnpos.y = Random.Range (15, 50);
					finalSpawnpos.z = BombSpawnPositions [i].z;
					GameObject bominst = Instantiate(BombPrefab,finalSpawnpos, Quaternion.identity);

                }
            }

        }
    }
	void trackPlayer(){
		if (!Dead) {
			int playerpos = Player.GetComponent<PlayerScript> ().index;
			Instantiate (BombPrefab, BombSpawnPositions [playerpos], Quaternion.identity);


		}
	}
	public void resetTimer(){
		bSTimer = 0;
		tPTimer = 0;
		sCTimer = 0;
        sHTimer = 0;
		bombSpawnTimer = BombTimer;
		spawnCoinTimer = CoinTimer;
        shieldTimer = ShieldTimer;
		trackPlayerTimer = TrackTimer;
	}
  
} 