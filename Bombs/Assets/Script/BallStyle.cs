using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStyle : MonoBehaviour {
    public DATABASE DB;
	void Start () {
        DB = GameObject.FindGameObjectWithTag("DB").GetComponent<DATABASE>();

        for (int i = 0; i < DB.itemsNames.Length;i++) {
            if(PlayerPrefs.GetString("name") == DB.itemsNames[i]) {
                gameObject.GetComponent<Renderer>().material.mainTexture = DB.ballTextures[i];
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", DB.ballAlbedoColors[i]);
            }
        }
	}

}
