using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public Vector3[] spawnPositions = new Vector3[9];
    PlayerScript player;
    public int bombCount;
    int spawnRate;
    private void Start()
    {
        spawnPositions = GenerateSpwanPositions(3, 3);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        StartCoroutine(StartWave(5));
    }

    public Vector3[] GenerateSpwanPositions(int col, int row)
    {
        Vector3[] pos = new Vector3[9];

        int index = 0;
        for (int j = 0; j < col; j++)
        {

            for (int i = 0; i < row; i++)
            {

                pos[index] = new Vector3(-3 + i * 3, 0, 6 - j * 3);
                index++;

            }
        }
        return pos;

    }

    void SpawnBomb(int i)
    {
        int height = Random.Range(25, 50);
        GameObject n = Instantiate(bombPrefab, spawnPositions[i] + new Vector3(0, height, 0), Quaternion.identity);
        BombsCount(1);
    }

    void SpawnStack(int rate)
    {

        int playerIndex = player.index;
        int numberOfBombs = Random.Range(3, 8);
        int[] stackIndices = GetUniqueRandomArray(0, 9, numberOfBombs, playerIndex);
        for (int i = 0; i < stackIndices.Length; i++)
        {
            SpawnBomb(stackIndices[i]);
        }
        spawnRate -= 1;

    }

    int[] GetUniqueRandomArray(int min, int max, int count, int playerIndex)
    {
        int[] result = new int[count];
        List<int> numbersInOrder = new List<int>();
        for (var x = min; x < max; x++)
        {
            if (x != playerIndex)
                numbersInOrder.Add(x);
        }
        for (var x = 0; x < count - 1; x++)
        {
            var randomIndex = Random.Range(0, numbersInOrder.Count);
            result[x] = numbersInOrder[randomIndex];
            numbersInOrder.RemoveAt(randomIndex);
        }
        result[count - 1] = playerIndex;
        return result;
    }


    IEnumerator StartWave(int rate)
    {
        Debug.Log("new wave starting in 3 seconds");
        spawnRate = rate;
        yield return new WaitForSeconds(3);
        SpawnStack(spawnRate);
    }



    public int BombsCount(int i)
    {
        bombCount += i;
        if (spawnRate == 0 && bombCount == 0)
        {
            StartCoroutine(StartWave(3));
        }
        else if (bombCount == 0) SpawnStack(spawnRate);
        return bombCount;
    }



    void PrintArray(int[] arr)
    {
        string log = "[ ";
        for (int i = 0; i < arr.Length; i++)
        {
            log += arr[i] + " , ";
        }
        log += " ]";
        Debug.Log(log);
    }
}