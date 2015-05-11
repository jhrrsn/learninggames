using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!other.isTrigger || other.gameObject.tag != "spawner") {
			GetComponent<Rigidbody2D> ().Sleep ();
			GetComponent<Animator> ().SetBool ("hit", true);
			GetComponent<BoxCollider2D> ().enabled = false;
			Destroy (gameObject, 0.416f);
		}
	}
}
