using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	public MobHealth mob;
	public int maxMobs;
	public float spawnRate;
	public int maxHealth;
	public int scoreGained;
	public Sprite inactiveSprite;

	private float nextSpawn = 0.0f;
	private int currentHealth;
	private int currentMobs;
	private bool active;
	private GameController gc;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		currentMobs = 0;
		active = false;
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (active && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;

			if (currentMobs < maxMobs) {
				currentMobs++;
				MobHealth mh = (MobHealth) Instantiate(mob, transform.position, Quaternion.identity);
				mh.SetSpawner(gameObject.GetComponent<SpawnerController>());
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "projectile") {
			currentHealth -= 1;
			if (currentHealth == 0) {
				active = false;
				gc.IncreaseScore (scoreGained);
				GetComponent<SpriteRenderer> ().sprite = inactiveSprite;
			}
		} else if (other.gameObject.tag == "Player")
			active = true;
	}

	public void DecreaseMobCount() {
		currentMobs--;
	}
}