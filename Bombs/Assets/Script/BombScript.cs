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
            Destroy(gameObject);
            GameManager.GetComponent<ScoreManager>().score += 1;
            GameManager.GetComponent<ScoreManager>().scoreBox.text = GameManager.GetComponent<ScoreManager>().score.ToString();
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("GameOver");
            SceneManager.LoadScene(2);
        }
    }
}
