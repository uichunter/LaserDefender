﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text pointText = GetComponent<Text>();
		pointText.text = ScoreKeeper.score.ToString();
		ScoreKeeper.ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
