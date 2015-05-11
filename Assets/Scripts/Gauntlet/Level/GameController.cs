using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text scoreText;

	private int score;
	private int currentKeys;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		currentKeys = 0;
		score = 0;
	}

	public void AlterKeys(int n) {
		currentKeys += n;
	}

	public int GetKeys() {
		return currentKeys;
	}

	public void IncreaseScore(int n) {
		score += n;
		scoreText.text = score.ToString ();
	}
}
