using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float lerpSpeed;
    public Vector3[] Positions = new Vector3[9];
    public int index;
	// Use this for initialization
	void Start () {
        index = 4;
        transform.position = Positions[index];
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        transform.position = Vector3.Lerp(transform.position, Positions[index], lerpSpeed * Time.deltaTime);
		
	}







    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index >= 3)
                index -= 3;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index <= 5)
                index += 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index == 2 || index == 5)
                return;
            if (index <= 7)
                index += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index == 3 || index == 6)
                return;
            if (index >= 1)
                index -= 1;
        }
    }
}
