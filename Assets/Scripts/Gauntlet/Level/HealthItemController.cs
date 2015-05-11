using UnityEngine;
using System.Collections;

public class HealthItemController : MonoBehaviour {

	public int healthGained;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			PlayerHealth ph = other.GetComponent<PlayerHealth>();

			ph.IncreaseHealth(healthGained);

			// Destroy self
			Destroy(transform.parent.gameObject);
		} else if (other.gameObject.tag == "projectile") {
			Destroy (transform.parent.gameObject);
		}
	}
}
