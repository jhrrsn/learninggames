using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth;

	private Text healthText;
	private int currentHealth;
	private float nextHurt = 0.0f;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		InvokeRepeating ("HealthTick", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "mob" && Time.time > nextHurt) {
			nextHurt = Time.time + 1f;
			MobDamage md = other.gameObject.GetComponent<MobDamage>();
			currentHealth -= md.GetDamage();
			healthText.text = currentHealth.ToString();
			GetComponent<Animator> ().CrossFade("PlayerHurt", 0.1f);
		}
	}

	void HealthTick() {
		currentHealth -= 1;
		healthText.text = currentHealth.ToString();
	}

	public void IncreaseHealth(int healthUp) {
		currentHealth += healthUp;
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
		healthText.text = currentHealth.ToString();
	}
}
