using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int  score;
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
		ScoreKeeper.score = input;
	}


	public static void ResetScore ()
	{
		ScoreKeeper.score = 0;
	}


	public void Score (int points)
	{
		setScore(getScore()+points);
		scoreText.text = getScore().ToString();
	}
}
