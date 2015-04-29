using UnityEngine;
using System.Collections;

public class BreakoutBallController : MonoBehaviour {

	public float sloMotion;
	public float sloRate;
	public float angleForce;
	public float escapeForce;
	public float magnetForce;
	public Vector2 launchForce;
	public AudioClip [] bounceClips;

	private int bounceCount;
	private Vector3 startPosition;
	private float storedPitch;
	private AudioSource ballSFX;
	private bool launched;
	private bool wallBounce;
	private bool paddleBounce;
	private Rigidbody2D rb;
	private ScoreCounter scoreText;
	private LivesCounter livesText;

	// Use this for initialization
	void Start () {
		ballSFX = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<ScoreCounter> ();
		livesText = GameObject.FindGameObjectWithTag ("livesText").GetComponent<LivesCounter> ();
		launched = false;
		wallBounce = false;
		paddleBounce = false;
	}
	
	// Update is called once per frame
	void Update () {

		// If 'launch' is pressed and not already launched, apply upwards force with some horizontal variation.
		if (Input.GetButtonDown ("Launch") && !launched) {
			launched = true;
			rb.AddForce (launchForce);
			ballSFX.PlayOneShot (bounceClips[0]);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		// hit paddle
		if (other.gameObject.tag == "Player") {
			if (Mathf.Abs(rb.velocity.x) < 0.1f) {
				if (transform.position.x < 0) {
					rb.AddForce(Vector2.right * escapeForce*0.2f);
				} else {
					rb.AddForce(Vector2.right * -escapeForce*0.2f);
				}
			}
			wallBounce = false;
			paddleBounce = true;
			bounceCount = 0;
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		} 

		// hit block
		else if (other.gameObject.tag == "block") {
			wallBounce = false;
			paddleBounce = false;
			scoreText.UpdateScore();
			ballSFX.PlayOneShot (bounceClips[bounceCount]);
			if (bounceCount < 7) bounceCount += 1;
		} 

		// hit wall
		else {
			paddleBounce = false;
			if (wallBounce && rb.velocity.y > -0.2f) {
				rb.AddForce(Vector2.up * escapeForce);
			} else if (wallBounce && rb.velocity.y <= -0.2f){
				rb.AddForce(Vector2.up * -escapeForce*0.1f);
			}
			ballSFX.PlayOneShot (bounceClips[bounceCount]);
			if (bounceCount < 7) bounceCount += 1;
			wallBounce = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Respawn") {
			int lives = livesText.DecreaseLives ();
			if (lives == 0) {
				Debug.Log ("Game Over");
			} else {
				launched = false;
				rb.velocity = Vector2.zero;
				transform.position = new Vector2 (-7f, 0f);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && !paddleBounce) {
			if (Time.timeScale > sloMotion) {
				Time.timeScale -= sloRate * Time.deltaTime;
				Time.fixedDeltaTime = 0.02F * Time.timeScale;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		}
	}
}