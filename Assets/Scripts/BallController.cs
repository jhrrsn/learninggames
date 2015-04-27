using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public bool serveToLeft;
	public float ballForce;
	public float angleForce;
	public float escalationForce;
	public AudioClip serve;

	private AudioSource ballSFX;
	private Rigidbody2D rb;
	private MainLightController mainLight;
	private TextController scoreTextController;

	// Use this for initialization
	void Start () {
		ballSFX = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D> ();
		mainLight = GameObject.FindGameObjectWithTag ("mainLight").GetComponent<MainLightController> ();
		scoreTextController = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<TextController> ();
		mainLight.RaiseLights ();
		scoreTextController.LowerAlpha ();
		Invoke ("LaunchBall", 4f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			PaddleController paddle = other.gameObject.GetComponent<PaddleController> ();
			float paddleVertical = paddle.GetVertical ();
			rb.AddForce (Vector2.up * paddleVertical * angleForce);
			if (other.relativeVelocity.x < 0f) {
				rb.AddForce (Vector2.right * escalationForce);
			} else {
				rb.AddForce (Vector2.right * -escalationForce);
			}
//			rb.AddForce (Vector2.right * paddleVertical * angleForce);
		}
	}

	void LaunchBall() {
		ballSFX.PlayOneShot (serve);
		if (serveToLeft)
			rb.AddForce (new Vector2(1, 0.4f) * ballForce);
		else
			rb.AddForce (new Vector2(1, 0.4f) * -ballForce);
	}

	public void ResetPosition() {
		transform.position = new Vector3 (0f, 0f, -0.5f);
		rb.velocity = new Vector2 (0f, 0f);
		rb.angularVelocity = 0f;
		mainLight.RaiseLights ();
		scoreTextController.LowerAlpha ();
		Invoke ("LaunchBall", 4f);
	}

	public void ResetLaunch() {
		serveToLeft = !serveToLeft;
		Invoke ("ResetPosition", 5f);
	}
}
