using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class shieldSphereBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
	}
	 
	// Update is called once per frame
	void Update () {
        DOTween.Sequence().Append(gameObject.GetComponent<Renderer>().material.DOColor(new Color(0, 234, 255, 0), 10f)).AppendCallback(() => {
            Destroy(gameObject);
        });

	}

   
    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="bomb") {
            other.gameObject.GetComponent<BombScript>().Explode();
            Debug.Log("deflect");
        }
    }


}
