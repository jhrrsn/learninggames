using UnityEngine;
using System.Collections;

public class BreakoutPaddleController : MonoBehaviour {

	public float paddleSpeed;
	public float maxX;

	private float hValue;

	// Use this for initialization
	void Start () {
	
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
}
