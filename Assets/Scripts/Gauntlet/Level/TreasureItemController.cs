using UnityEngine;
using System.Collections;

public class TreasureItemController : MonoBehaviour {

	public int scoreGained;

	private GameController gc;
	
	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			gc.IncreaseScore (scoreGained);

			// Destroy self
			Destroy (transform.parent.gameObject);
		} else if (other.gameObject.tag == "projectile") {
			Destroy (transform.parent.gameObject);
		}
	}
}
