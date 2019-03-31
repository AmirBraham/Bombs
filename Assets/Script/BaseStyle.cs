using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStyle : MonoBehaviour {
    public DATABASE DB;

	// Use this for initialization
	void Start () {
        DB = GameObject.FindGameObjectWithTag("DB").GetComponent<DATABASE>();
        for (int i = 0; i < DB.itemsNames.Length; i++)
        {
            if (PlayerPrefs.GetString("name") == DB.itemsNames[i])
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = DB.baseTextures[i];
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", DB.baseAlbedoColors[i]);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
