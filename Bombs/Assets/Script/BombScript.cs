
using UnityEngine;
using UnityEngine.SceneManagement;
public class BombScript : MonoBehaviour {
    GameObject GameManager;
    public float bombSpeed;
    public GameObject Explosion;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.down * bombSpeed;
        GameManager = GameObject.Find("GameManager");
        Explosion.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.GetComponent<ScoreManager>().Increment();
            GameObject InstanExplosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
            InstanExplosion.SetActive(true);
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
