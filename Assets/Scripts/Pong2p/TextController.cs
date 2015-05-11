using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public float rate;

//	private int score1;
//	private int score2;
//	private float alpha;
	private bool raiseAlpha;
	private bool lowerAlpha;
	private Text mainText;

	// Use this for initialization
	void Start () {
//		score1 = 0;
//		score2 = 0;
//		alpha = 1f;
		raiseAlpha = false;
		lowerAlpha = false;
		mainText = GetComponent<Text> ();
	}
	
	void FixedUpdate () {
		float currentAlpha = mainText.color.a;
		if (currentAlpha <= 0) {
			mainText.color = new Color(1f, 1f, 1f, 0f);
			lowerAlpha = false;
		} else if (currentAlpha >= 1f) {
			mainText.color = new Color(1f, 1f, 1f, 1f);
			raiseAlpha = false;
		}
		
		if (lowerAlpha) {
			currentAlpha -= rate;
			mainText.color = new Color(1f, 1f, 1f, currentAlpha);
		} else if (raiseAlpha) {
			currentAlpha += rate;
			mainText.color = new Color(1f, 1f, 1f, currentAlpha);
		}
	}

	public void RaiseAlpha() {
		raiseAlpha = true;
	}

	public void LowerAlpha() {
		lowerAlpha = true;
	}

//	void DisplayScore() {
//
//	}
}
