using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {

	public int playerNumber;
	public float paddleSpeed;
	public AudioClip volley;

	private AudioSource paddleSFX;
	private string inputName;
	private float yValue;

	// Use this for initialization
	void Start () {
		inputName = "Vertical" + playerNumber;
		paddleSFX = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float v = Input.GetAxis (inputName);
		yValue = map(v, -1f, 1f, -3.5f, 3.5f);
		Vector2 newPos = transform.position;
		float oldY = transform.position.y;
		if ((oldY < 3.5f && oldY > -3.5f) || (oldY >= 3.5f && yValue < 0f) || (oldY <= -3.5f && yValue > 0f))
			newPos.y += yValue * paddleSpeed;
		transform.position = newPos;

	}

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}

	void OnCollisionEnter2D(Collision2D other) {
		float angle = Vector2.Angle (transform.position, other.transform.position);
		float pitchShift = map (angle, 0f, 10f, 0.8f, 1.2f);
		paddleSFX.pitch = pitchShift;
		paddleSFX.PlayOneShot (volley);
	}

	public float GetVertical() {
		return yValue;
	}
}