using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public Text scoreText;

	private BallController ball;
	private MainLightController mainLight;
	private TextController scoreTextController;
	private int score1;
	private int score2;
	private int player;

	void Start () {
		ball = GameObject.FindGameObjectWithTag ("ball").GetComponent<BallController>();
		mainLight = GameObject.FindGameObjectWithTag ("mainLight").GetComponent<MainLightController> ();
		scoreTextController = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<TextController> ();
	}

	public void IncreaseScore(int player) {
		if (player == 1) {
			score1 += 1;
		} else if (player == 2) {
			score2 += 1;
		}
		scoreText.text = score1 + " - " + score2;

		ball.ResetLaunch ();
		mainLight.DimLights ();
		scoreTextController.RaiseAlpha ();
	}

	/*	
	 * GameObject gameObject = GameObject.FindGameObjectWithTag ("scoreText");
	 * TextController scoreText = gameObject.GetComponent<TextController> ();
	 * scoreText.IncreaseScore (player);
	*/
}
