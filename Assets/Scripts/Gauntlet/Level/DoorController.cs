using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	private GameController gc;

	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {

			int nKeys = gc.GetKeys();

			if (nKeys > 0) {
				// Add +1 key
				gc.AlterKeys(-1);

				// Destroy self
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
