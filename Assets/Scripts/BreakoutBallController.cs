using UnityEngine;
using System.Collections;

public class BreakoutBallController : MonoBehaviour {

	public float angleForce;
	public float launchForce;

	private bool launched;
	private Rigidbody2D rb;
	private Transform paddle;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		paddle = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		launched = false;
	}
	
	// Update is called once per frame
	void Update () {
		// If 'launch' is pressed and not already launched, apply upwards force with some horizontal variation.
		if (Input.GetButtonDown ("Launch") && !launched) {
			launched = true;
			float hVariation = Random.Range (-50f, 50f);
			rb.AddForce (new Vector2 (hVariation, launchForce));
		}
		// If not launched, follow paddle x position.
		else if (!launched) {
			Vector3 newPos = transform.position;
			newPos.x = paddle.position.x;
			transform.position = newPos;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		// If colliding with a block, destroy it.
		if (other.gameObject.tag == "block") {
			other.gameObject.GetComponent<Renderer>().enabled = false;
			Destroy (other.gameObject, 0.1f);	
		} 
		// If colliding with the paddle, add a force relative to the paddle movement.
		else if (other.gameObject.tag == "Player") {
			BreakoutPaddleController paddle = other.gameObject.GetComponent<BreakoutPaddleController> ();
			float paddleHorizontal = paddle.GetHorizontal ();
			rb.AddForce (Vector2.right * paddleHorizontal * angleForce);
		}
	}
}