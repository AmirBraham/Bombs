using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDesktroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnEnable()
        {
            Destroy(gameObject, 2.2f);
        }
}
