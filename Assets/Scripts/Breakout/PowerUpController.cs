using UnityEngine;
using System.Collections;

public enum type {
	wide,time
}

public class PowerUpController : MonoBehaviour {

	public float duration;
	public type typeOfPowerup;

	// Use this for initialization
	void Start () {
	}
	

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && !other.isTrigger) {
			if (typeOfPowerup == type.wide) {
				BreakoutPaddleController paddle = other.gameObject.GetComponent<BreakoutPaddleController> ();
				paddle.MakeWide (duration);
			} else if (typeOfPowerup == type.time) {
				BreakoutPaddleController paddle = other.gameObject.GetComponent<BreakoutPaddleController> ();
				paddle.MakeTime (duration);
			}
			Destroy (gameObject);
		}
	}
}
