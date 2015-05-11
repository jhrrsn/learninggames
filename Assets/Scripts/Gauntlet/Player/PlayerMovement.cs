using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public bool facingRight;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetButton ("Fire1")) {
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");

			Vector3 input = new Vector3 (h, v, 0f);

			if (!anim.GetBool ("walking") && input.magnitude > 0) {
				anim.SetBool ("walking", true);
			} else if (anim.GetBool ("walking") && input.magnitude == 0) {
				anim.SetBool ("walking", false);
			}

			transform.position = Vector2.MoveTowards (transform.position, transform.position + input, moveSpeed * Time.deltaTime);

			// Flip sprite to face direction of travel.
			if (h < 0 && facingRight)
				Flip ();
			else if (h > 0 && !facingRight)
				Flip ();
		} else {
			anim.SetBool ("walking", false);
		}
	}

	public void Flip () {
		facingRight = !facingRight;
		Vector3 flipped = transform.localScale;
		flipped.x = -flipped.x;
		transform.localScale = flipped;
	}

	public bool GetFacingRight() {
		return facingRight;
	}
}
