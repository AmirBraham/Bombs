using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {
    [SerializeField]
    float bombSpeed;
    [SerializeField]
    float MaxSpeed;
	// Use this for initialization
	void Start () {
        bombSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (bombSpeed<MaxSpeed)
            bombSpeed += Time.deltaTime;
        
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
        if (bombs != null)
        {
            foreach (GameObject bomb in bombs)
            {
                bomb.GetComponent<BombScript>().bombSpeed = bombSpeed;
            }
        }
		
	}
}
