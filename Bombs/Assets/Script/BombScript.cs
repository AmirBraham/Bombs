
using UnityEngine;
using UnityEngine.SceneManagement;
public class BombScript : MonoBehaviour {
    GameObject GameManager;
	BombSpawner bombSpawner;
    public float bombSpeed;
    public GameObject Explosion;
    public GameObject Player;
    public GameObject shadow;

    public Vector3 StartingPosition;
    GameObject shadowinst;
	// Use this for initialization
	void Start () {
        bombSpeed = Random.Range(1, 6);
        GetComponent<Rigidbody>().velocity = Vector3.down * bombSpeed;
        GameManager = GameObject.Find("GameManager");
		bombSpawner = GameObject.Find ("Spawner").GetComponent<BombSpawner> ();
        Explosion.SetActive(false);
        StartingPosition = transform.position;
        shadowinst = Instantiate(shadow, new Vector3(transform.position.x, -0.66f, transform.position.z), Quaternion.Euler(90, 0, 0));

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(StartingPosition.x, 0, StartingPosition.z), 0.4f);
        UpdateShadow(shadowinst);
	}

    void UpdateShadow(GameObject a)
    {
        a.GetComponent<SpriteRenderer>().color = new Color(a.GetComponent<SpriteRenderer>().color.r, a.GetComponent<SpriteRenderer>().color.b, a.GetComponent<SpriteRenderer>().color.g, 1 - ((transform.position.y) / 30));

        a.transform.localScale = new Vector3( Mathf.Abs(transform.position.y + 8f)/ 9.6f,Mathf.Abs(transform.position.y + 8f) / 9.6f, 1);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameObject InstanExplosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
            InstanExplosion.SetActive(true);
            Destroy(gameObject);
            Destroy(shadowinst);
        }
        if(collision.gameObject.tag == "Player")
        {
            GameManager.GetComponent<ScoreManager>().CheckHighScore();
            GameObject InstanExplosion = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
			bombSpawner.Dead = true;
			bombSpawner.resetTimer ();
            bombSpawner.enabled = false;
            InstanExplosion.SetActive(true);
            Destroy(collision.gameObject);
            Instantiate(Player,new Vector3(0,0,3),Quaternion.identity);
            GameManager.GetComponent<GameManager>().RestartGame();
            Destroy(gameObject);
            Destroy(shadowinst);
        }
    }
}
