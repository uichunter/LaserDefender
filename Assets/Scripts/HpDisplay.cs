using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HpDisplay : MonoBehaviour {
	Text currentHpText;
	// Use this for initialization
	void Start () {
	 currentHpText = gameObject.GetComponent<Text>();
	}

	public void setHpText (int hp)
	{
		currentHpText.text = hp.ToString ();
	}
}
