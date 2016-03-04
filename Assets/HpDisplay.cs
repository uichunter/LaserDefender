using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpDisplay : MonoBehaviour {
	Text currentHpText;
	int Hp;
	// Use this for initialization
	void Start () {
	 currentHpText = gameObject.GetComponent<Text>();
     Hp = GameObject.Find("palyerSHip1_red").GetComponent<PlayerController>().playerHp;
	}



	// Update is called once per frame
	void Update () {
		Hp = GameObject.Find("palyerSHip1_red").GetComponent<PlayerController>().playerHp;
		currentHpText.text = Hp.ToString();
	}
}
