using UnityEngine;
using System.Collections;

public class BreakoutPaddleController : MonoBehaviour {

	public float paddleSpeed;
	public float maxX;
	public AudioClip paddleClip;

	private BoxCollider2D paddleTrigger;

	private AudioSource paddleSFX;
	private float hValue;

	// Use this for initialization
	void Start () {
		paddleTrigger = GetComponents<BoxCollider2D> () [1];
		paddleSFX = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		hValue = map(h, -1f, 1f, -3.5f, 3.5f);
		Vector2 newPos = transform.position;
		float oldX = transform.position.x;
		if ((oldX < maxX && oldX > -maxX) || (oldX >= maxX && hValue < 0f) || (oldX <= -maxX && hValue > 0f))
			newPos.x += hValue * paddleSpeed * Time.deltaTime;
		transform.position = newPos;
	}

	public float GetHorizontal() {
		return hValue;
	}

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}


	// Wide powerup
	public void MakeWide(float duration) {
		Vector3 scale = transform.localScale;
		scale.x = 4f;
		transform.localScale = scale;
		maxX = 6.9f;
		Invoke ("UnMakeWide", duration);
	}

	void UnMakeWide() {
		Vector3 scale = transform.localScale;
		scale.x = 2f;
		maxX = 7.7f;
		transform.localScale = scale;
	}

	// Time powerup
	public void MakeTime(float duration) {
		paddleTrigger.enabled = true;

		Invoke ("UnMakeTime", duration);
	}

	void UnMakeTime() {
		paddleTrigger.enabled = false;
	}

	void OnCollisionEnter2D() {
		paddleSFX.PlayOneShot (paddleClip, 0.5f);
	}
}