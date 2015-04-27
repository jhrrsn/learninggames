using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	public int player;
	public AudioClip applause;

	private AudioSource applauseSFX;

	void Start () {
		applauseSFX = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		GameObject gameObject = GameObject.FindGameObjectWithTag ("GameController");
		ScoreController scoreController = gameObject.GetComponent<ScoreController> ();
		scoreController.IncreaseScore (player);
		applauseSFX.PlayOneShot (applause);
	}
}
