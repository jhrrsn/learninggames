using UnityEngine;
using System.Collections;

public class MobMovement : MonoBehaviour {

	public float moveSpeed;
	public bool kamikaze;

	private Transform playerPos;
	private bool alive;

	// Use this for initialization
	void Start () {
		playerPos = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) 
			transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if (kamikaze) {
				GetComponent<MobHealth>().Die ();
				alive = false;
			}
		}
	}
}
