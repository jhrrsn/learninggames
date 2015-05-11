using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class LivesCounter : MonoBehaviour {

	public AudioClip failClip;

	private AudioSource failSFX;
	private Text t;
	private int lives;

	void Start () {
		failSFX = GetComponent<AudioSource> ();
		t = GetComponent<Text> ();
		lives = 3;
	}
	
	// Use this for initialization
	public int DecreaseLives() {
		failSFX.PlayOneShot (failClip);
		lives -= 1;
		if (lives > 0)
			t.text = new string ('x', lives);
		else {
			t.text = "game over";
			Invoke ("ReloadLevel", 5f);
		}
		return lives;
	}

	void ReloadLevel() {
		Application.LoadLevel (Application.loadedLevel);
	}
}
