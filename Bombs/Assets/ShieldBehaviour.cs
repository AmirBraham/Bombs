using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShieldBehaviour : MonoBehaviour {
    public GameObject shieldSphere;
	// Use this for initialization
	void Start () {
        transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 1f);
        Destroy(gameObject, 8f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 6.0f * 20f * Time.deltaTime, 0);

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player") {
            Instantiate(shieldSphere,GameObject.FindGameObjectWithTag("Player").transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
