using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	private GameController gc;

	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			// Add +1 key
			gc.AlterKeys(1);

			// Destroy self
			Destroy(transform.parent.gameObject);
		}
	}
}
