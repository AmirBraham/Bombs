using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour
{
    GameObject GameManager;
    public float lerpSpeed;
    public Vector3[] Positions = new Vector3[9];
    public int index;
    // Use this for initialization
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        index = 4;
        Positions = GameObject.Find("Spawner").GetComponent<Spawner>().GenerateSpwanPositions(3, 3);
        transform.position = Positions[index];

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Positions[index], lerpSpeed * Time.deltaTime);
    }

    public void moveRight()
    {
        if (index == 2 || index == 5)
            return;
        if (index <= 7)
            index += 1;
    }
    public void moveLeft()
    {
        if (index == 3 || index == 6)
            return;
        if (index >= 1)
            index -= 1;

    }
    public void moveUp()
    {
        if (index >= 3)
            index -= 3;

    }
    public void moveDown()
    {

        if (index <= 5)
            index += 3;

    }



}
