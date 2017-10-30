using UnityEngine;
public class BombSpawner : MonoBehaviour
{
    public Vector3[] BombSpawnPositions = new Vector3[9];
    GameObject Player;
    public bool Dead;
    public GameObject BombPrefab;
    int spawnLimit = 7;
    void Start()
    {
        InvokeRepeating("spawnPattern", 1.0f, 3f);

    }

    void spawnPattern()
    {
        if(!Dead) {
            int[] randomSkippedBombs = { (int)Random.Range(0, spawnLimit), (int)Random.Range(0, spawnLimit) };
            Debug.Log(randomSkippedBombs[1]);
            for (int i = 0; i < spawnLimit; i++)
            {
                if (!(randomSkippedBombs[0] == i || randomSkippedBombs[1] == i))
                    Instantiate(BombPrefab, BombSpawnPositions[i], Quaternion.identity);
            }
        }

    }
}