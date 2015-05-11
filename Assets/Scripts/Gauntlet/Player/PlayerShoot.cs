using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Rigidbody2D laser;
	public float shotForce;
	public float fireRate;

	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Shoot (h, v);
		}
	}

	void Shoot (float h, float v) {
		Vector2 shotDirection = Vector2.zero;
		Rigidbody2D rb = (Rigidbody2D) Instantiate (laser, transform.position, transform.rotation);
		Transform t = rb.GetComponent<Transform> ();

		/* 
		 * Shot Orientation
		 */

		if (h < 0) {
			Vector3 flipped = t.localScale;
			flipped.x = -flipped.x;
			t.localScale = flipped;
		}

		/* 
		 * Player Orientation
		 */

		PlayerMovement pm = GetComponent<PlayerMovement> ();

		if (h < 0 && pm.facingRight)
			pm.Flip ();
		else if (h > 0 && !pm.facingRight)
			pm.Flip ();


		/* 
		 * Shot Direction
		 */

		// Shooting right
		if ((h == 0 && v == 0) || (h > 0 && v == 0)) {
			shotDirection = Vector2.right;
		} 
		// Shooting up + right
		else if (h > 0 && v > 0) {
			shotDirection = new Vector2 (1f, 1f);
			t.localEulerAngles = new Vector3(0f,0f,45f);
		}
		// Shooting down + right
		else if (h > 0 && v < 0) {
			shotDirection = new Vector2 (1f, -1f);
			t.localEulerAngles = new Vector3(0f,0f,-45f);
		}
		// Shooting left
		else if (h < 0 && v == 0) {
			shotDirection = -Vector2.right;
		} 
		// Shooting up + left
		else if (h < 0 && v > 0) {
			shotDirection = new Vector2 (-1f, 1f);
			t.localEulerAngles = new Vector3(0f,0f,-45f);
		}
		// Shooting down + left
		else if (h < 0 && v < 0) {
			shotDirection = new Vector2 (-1f, -1f);
			t.localEulerAngles = new Vector3(0f,0f,45f);
		}
		// Shooting up
		else if (h == 0 && v > 0) {
			shotDirection = Vector2.up;
			t.localEulerAngles = new Vector3(0f,0f,90f);
		}
		// Shooting down
		else if (h == 0 && v < 0) {
			shotDirection = -Vector2.up;
			t.localEulerAngles = new Vector3(0f,0f,-90f);
		}
			
		rb.AddForce(shotDirection * shotForce);
	}

	int GetDirection(float h, float v) {
		if (h > 0 && v == 0) {
			return 0;
		} 
		// Shooting up + right
		else if (h > 0 && v > 0) {
			return 7;
		}
		// Shooting down + right
		else if (h > 0 && v < 0) {
			return 1;
		}
		// Shooting left
		else if (h < 0 && v == 0) {
			return 4;
		} 
		// Shooting up + left
		else if (h < 0 && v > 0) {
			;
			return 5;
		}
		// Shooting down + left
		else if (h < 0 && v < 0) {
			return 3;
		}
		// Shooting up
		else if (h == 0 && v > 0) {
			return 6;
		}
		// Shooting down
		else if (h == 0 && v < 0) {
			return 2;
		} 
		// Else return error value
		else {
			return 99;
		}
	}
}
