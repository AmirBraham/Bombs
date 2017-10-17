
using UnityEngine;
using UnityEngine.SceneManagement;
public class BombScript : MonoBehaviour {
    GameObject GameManager;
    public float bombSpeed;
    public GameObject Explosion;
    public GameObject Player;
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
            GameManager.GetComponent<ScoreManager>().CheckHighScore();
            GameObject InstanExplosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().enabled = false;
            InstanExplosion.SetActive(true);
            Destroy(collision.gameObject);
            Instantiate(Player,new Vector3(0,0,3),Quaternion.identity);
            GameManager.GetComponent<GameManager>().RestartGame();
            Destroy(gameObject);
        }
    }
}
