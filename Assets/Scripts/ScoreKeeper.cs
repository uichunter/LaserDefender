using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	private int score;
	private Text scoreText;

	void Start ()
	{
		scoreText = GetComponent<Text>();
		ResetScore();
	}

	int getScore ()
	{
		return score;
	}

	void setScore(int input)
	{
		this.score = input;
	}


	public void ResetScore ()
	{
		setScore(0);
		scoreText.text = 0.ToString();
	}


	public void Score (int points)
	{
		setScore(getScore()+points);
		scoreText.text = getScore().ToString();
	}
}
