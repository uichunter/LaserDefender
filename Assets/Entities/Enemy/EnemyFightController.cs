using UnityEngine;
using System.Collections;

public class EnemyFightController : MonoBehaviour {	
	public int enemyHpMax;
	public float missleSpeed;
	public GameObject missleType;
	public float shotsPerSec = 0.5f;
	public int EnemyScore;
	public AudioClip enemyFireSound;
	public AudioClip enemyCrashSound;

	private int enemyHp;
	private ScoreKeeper scorekeeper;

	void Start ()
	{
		setScoreKeeper();
		enemyHp = enemyHpMax;
	}

	void setScoreKeeper ()
	{
		scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	//TODO Specify the type of collider is projectile or spaceship.
	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider) {
			Projectile biu = collider.gameObject.GetComponent<Projectile> ();
			Hit (biu);
			biu.Hit ();
		}
	}

	void Hit (Projectile biu)
	{
		enemyHp -= biu.GetDamage();
		if (enemyHp <= 0) {
			scorekeeper.Score(EnemyScore);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(enemyCrashSound,transform.position);
			//this.GetComponent<AudioSource>().;
		}
	}

	void Update ()
	{
		float probability;
		probability = Time.deltaTime * shotsPerSec;
		if (Random.value <= probability) {
			Fire ();
		}
	}

	void Fire ()
	{
		Vector3 spriteBorder = new Vector3(0f,GetComponent<SpriteRenderer>().sprite.bounds.size.y,0f);
		GameObject biu = Instantiate(missleType,transform.position - spriteBorder,Quaternion.identity) as GameObject;
		biu.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-missleSpeed);
		AudioSource.PlayClipAtPoint(enemyFireSound,transform.position);
	}

}
