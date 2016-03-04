using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public int playerHpMax;
	public string keyUp;
	public string keyDown;
	public string keyLeft;
	public string keyRight;
	public GameObject firePrefab;
//TODO Add a fire effect to projectile;
//	public GameObject fireEffect;
	public float beamSpeed = 5f;
	public float fireRate = 0.2f;

	private int playerHp;
    Vector3 spriteBorder;

	// Use this for initialization
	void Start () {
	//TODO if (hasStarted){Screen.showCursor = false;}
		setPlayerHp();
		SetMoveSpeed();
	}

	void SetMoveSpeed ()
	{
		this.moveSpeed = this.moveSpeed * Time.deltaTime;
	}

	void setPlayerHp ()
	{
		playerHp = playerHpMax;
	}
	// Update is called once per frame
	void Update () {
		Move();
		Fire();
	}

	void Move ()
	{
		KeyController (keyUp, keyDown, keyLeft, keyRight);
	}

	private void MouseController()
	{
		Vector3 shipPo = new Vector3();
		shipPo = Input.mousePosition / Screen.width*16;
		transform.position = ClimpShiPo(shipPo);
		//if (Input.GetMouseButtonDown(2)) {singleToneKey = true;}
	}

	private void KeyController (string keyUp,string keyDown, string keyLeft, string keyRight)
	{
	//If I use else if for other getkey condiction, the ship cant move toward oblique directrion;
		Vector3 shipPo = new Vector3();
		if (Input.GetKey (keyUp)|Input.GetKey(KeyCode.UpArrow)) {shipPo.y += moveSpeed;}
		if (Input.GetKey (keyDown)|Input.GetKey(KeyCode.DownArrow)) {shipPo.y -= moveSpeed;}
		if (Input.GetKey (keyLeft)|Input.GetKey(KeyCode.LeftArrow)) {shipPo.x -= moveSpeed;}
		if (Input.GetKey (keyRight)|Input.GetKey(KeyCode.RightArrow)) {shipPo.x += moveSpeed;}
		shipPo+=transform.position;
		transform.position = ClimpShiPo(shipPo);
	}

	 Vector3 ClimpShiPo (Vector3 shipPo)
	{
		Vector3 leftMost;
		Vector3 rightMost;

		spriteBorder = this.gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size/2;
		leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,10f))+spriteBorder;
		rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,1,10f))-spriteBorder;

		shipPo.x = Mathf.Clamp(shipPo.x,leftMost.x,rightMost.x);
		shipPo.y = Mathf.Clamp(shipPo.y,leftMost.y,rightMost.y);
		return shipPo;
	}

	void Fire ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("GenerateFire", 0.0000001f, fireRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("GenerateFire");
		}
	}
	void GenerateFire ()
	{
		Vector3 FirePo = new Vector3(0f,spriteBorder.y*2f);
		FirePo +=transform.position;
		GameObject beam = Instantiate (firePrefab, FirePo, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,beamSpeed);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile biu = collider.gameObject.GetComponent<Projectile> ();
		Hit (biu);
		biu.Hit ();
	}

	void Hit (Projectile biu)
	{
		playerHp -= biu.GetDamage();
		if (playerHp <= 0) {
			Destroy(gameObject);
		}
	}
}
