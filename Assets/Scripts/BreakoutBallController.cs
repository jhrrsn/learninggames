using UnityEngine;
using System.Collections;

public class BreakoutBallController : MonoBehaviour {

	public float bouncePitchUp;
	public float angleForce;
	public Vector2 launchForce;
	public AudioClip bounceClip;

	private Vector3 startPosition;
	private float storedPitch;
	private AudioSource ballSFX;
	private bool launched;
	private Rigidbody2D rb;
	private Transform paddle;
	private ScoreCounter scoreText;

	// Use this for initialization
	void Start () {
		ballSFX = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		paddle = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<ScoreCounter> ();
		launched = false;
	}
	
	// Update is called once per frame
	void Update () {
		// If 'launch' is pressed and not already launched, apply upwards force with some horizontal variation.
		if (Input.GetButtonDown ("Launch") && !launched) {
			launched = true;
			rb.AddForce (launchForce);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			ballSFX.pitch = 1.0f;
		} else if (other.gameObject.tag == "block") {
			scoreText.IncreaseScore();
			ballSFX.pitch += bouncePitchUp;
			ballSFX.Stop();
			ballSFX.PlayOneShot (bounceClip);
		} else {
			ballSFX.pitch += bouncePitchUp;
			ballSFX.Stop();
			ballSFX.PlayOneShot (bounceClip);
		}
	}

	void OnTriggerEnter2D() {
		launched = false;
		rb.velocity = Vector2.zero;
		transform.position = new Vector2 (-7f, 0f);
	}
}