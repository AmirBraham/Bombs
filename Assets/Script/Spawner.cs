using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public Vector3[] spawnPositions = new Vector3[9];
    PlayerScript player;
    private void Start()
    {
        GenerateSpwanPositions(3, 3);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void GenerateSpwanPositions(int col, int row)
    {
        int index = 0;
        for (int j = 0; j < col; j++)
        {

            for (int i = 0; i < row; i++)
            {

                spawnPositions[index] = new Vector3(-3 + i * 3, 0, 6 - j * 3);
                index++;

            }
        }

    }

    void SpawnBomb(int i)
    {
        int height = Random.Range(25, 50);
        GameObject n = Instantiate(bombPrefab, spawnPositions[i] + new Vector3(0, height, 0), Quaternion.identity);
    }

    void SpawnStack()
    {
        int playerIndex = player.index;
        int numberOfBombs = Random.Range(3, 8);

        int[] stackIndices = GetUniqueRandomArray(0, 9, numberOfBombs);
        PrintArray(stackIndices);


    }

    int[] GetUniqueRandomArray(int min, int max, int count)
    {
        int[] result = new int[count];
        List<int> numbersInOrder = new List<int>();
        for (var x = min; x < max; x++)
        {
            numbersInOrder.Add(x);
        }
        for (var x = 0; x < count; x++)
        {
            var randomIndex = Random.Range(0, numbersInOrder.Count);
            result[x] = numbersInOrder[randomIndex];
            numbersInOrder.RemoveAt(randomIndex);
        }

        return result;
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