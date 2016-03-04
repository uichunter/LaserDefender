using UnityEngine;
using System.Collections;

public class EnemyFightController : MonoBehaviour {	
	public int enemyHpMax;
	public float missleSpeed;
	public GameObject missleType;
	public float shotsPerSec = 0.5f;

	private int enemyHp;

	void Start ()
	{
		enemyHp = enemyHpMax;
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
			Destroy(gameObject);
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
	}

}
