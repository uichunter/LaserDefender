using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyPrefab;
	public float moveSpeed=1f;
	public float width=10f;
	public float height=5f;
	public float spwanDelay = 0.5f;

//	private float tempWidthMax;
//	private float tempWidthMin;
//	private float tempHeightMax;
//	private float tempHeightMin;
	private bool isMovingRight=false;
//	private bool isFirstTime=true;

	// Use this for initialization
	void Start () {
		SpwanUntilFull();
	}

//	void SpwanEnemy ()
//	{
//		foreach (Transform child in transform) {
//			GameObject enemy = Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
//			enemy.transform.parent = child;
//		}
//
//	}

	void SpwanUntilFull ()
	{
		Transform freePostition = NextFreePos ();
		if (freePostition) {
			GameObject enemy = Instantiate (enemyPrefab, freePostition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePostition;
		}

		if (NextFreePos()){
			Invoke ("SpwanUntilFull",spwanDelay);
		}
	}

    void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}

	// Update is called once per frame
	void Update () {
		EnemyMove();
		CheckEnemyAllDead();

	}

	void EnemyMove ()
	{
		Vector3 moveSpeedVector = new Vector3 (moveSpeed*Time.deltaTime, moveSpeed*Mathf.Sin (2*Time.time) * Time.deltaTime*0.5f, 0f);
		if (isMovingRight) {
			moveSpeedVector = moveSpeedVector+transform.position;
		}else {
			moveSpeedVector = transform.position-moveSpeedVector;
		}
		transform.position = ClimpEnemyPo(moveSpeedVector);

	}

	Vector3 ClimpEnemyPo (Vector3 shipPo)
	{
		Vector3 spriteBorder;
		Vector3 leftMost;
		Vector3 rightMost;

		//spriteBorder = enemyPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size/2;
		spriteBorder = new Vector2 (0.5f * width, 0.5f * height);
		leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 10f)) + spriteBorder;
		rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 10f)) - spriteBorder;

		shipPo.x = Mathf.Clamp (shipPo.x, leftMost.x, rightMost.x);
		shipPo.y = Mathf.Clamp (shipPo.y, leftMost.y, rightMost.y);

		if (shipPo.x == leftMost.x || shipPo.x == rightMost.x) {
			isMovingRight=!isMovingRight;
		}

		//Debug.Log(shipPo.x);
		return shipPo;
	}

	void CheckEnemyAllDead ()
	{
		if (AllEnemyDead ()) {
			SpwanUntilFull();
			//Destroy(this);
		}
	}

	Transform NextFreePos ()
	{
		foreach (Transform childPo in transform) {
			if (childPo.childCount == 0) {
				return childPo;
			}
		}
		return null;
	}

	bool AllEnemyDead ()
	{
		foreach (Transform childPo in transform) {
			if (childPo.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
