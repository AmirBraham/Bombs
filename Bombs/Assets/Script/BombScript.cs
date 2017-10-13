using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BombScript : MonoBehaviour {
    GameObject GameManager;
    public float bombSpeed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.down * bombSpeed;
        GameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.GetComponent<ScoreManager>().Increment();
            
            Destroy(gameObject);
            
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.GetComponent<ScoreManager>().CheckHighScore();
            SceneManager.LoadScene(2);
        }
    }
}
