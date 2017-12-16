using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStyle : MonoBehaviour {
    public DATABASE DB;

	// Use this for initialization
	void Start () {
        DB = GameObject.FindGameObjectWithTag("DB").GetComponent<DATABASE>();
        for (int i = 0; i < DB.itemsNames.Length; i++)
        {
            if (PlayerPrefs.GetString("name") == DB.itemsNames[i])
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = DB.PlaneTextures[i];
            }
        }
	}
}
