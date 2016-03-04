using UnityEngine;
using System.Collections;

public class BottonController : MonoBehaviour {
	public AudioClip buttonPressSound;

	//private AudioSource source;

	void OnMouseEnter ()
	{
		AudioSource.PlayClipAtPoint(buttonPressSound,transform.position);
		Debug.Log("Mouse over the button!");
	}
}
