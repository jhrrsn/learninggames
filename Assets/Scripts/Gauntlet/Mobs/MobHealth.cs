using UnityEngine;
using System.Collections;

public class MobHealth : MonoBehaviour {

	public int maxHealth;

	private int currentHealth;
	private SpawnerController mySpawner;
	
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "projectile") {
			currentHealth -= 1;
			if (currentHealth == 0) {
				Die ();
			}
		}
	}

	public void SetSpawner(SpawnerController spawner) {
		mySpawner = spawner;
	}

	public void Die() {
		mySpawner.DecreaseMobCount();
		GetComponent<Rigidbody2D> ().Sleep ();
		GetComponent<Animator> ().SetBool ("death", true);
		GetComponent<BoxCollider2D> ().enabled = false;
		Destroy (gameObject, 0.642f);
	}
}
