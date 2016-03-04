using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	void Awake (){
		//Debug.Log("Music Player Awake, instance: "+GetInstanceID());
		if (instance == null) {
			GameObject.DontDestroyOnLoad (gameObject);
			instance = this;
		} else {
			Destroy (gameObject);
			time++;
			Debug.Log(time+" gameObjects have been destroyed");
		}
	}

	static MusicPlayer instance=null;
	static int time=0;

	// Use this for initialization
	void Start ()
	{
		Debug.Log("Music Player Start, instance: "+GetInstanceID());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
