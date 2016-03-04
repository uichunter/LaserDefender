﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance=null;
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;

	// Use this for initialization
	void Start ()
	{
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			music = GetComponent<AudioSource>();
		} else {
			Destroy (gameObject);
		}
	}

	void OnLevelWasLoaded (int level)
	{
		Debug.Log ("Music player is load for " + level);
		music.Stop ();

		if (level == 0) {
			music.clip = startClip;
		} else if (level == 1) {
			music.clip = gameClip;
		} else if (level ==2){
			music.clip = endClip;
		}

		music.Play();

	}
}
