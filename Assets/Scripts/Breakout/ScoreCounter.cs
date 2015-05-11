using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public AudioClip winClip;
	
	private AudioSource winSFX;
	private Text t;

	void Start () {
		winSFX = GetComponent<AudioSource> ();
		t = GetComponent<Text> ();
		int nBlocks = GameObject.FindGameObjectsWithTag ("block").Length;
		t.text = (nBlocks).ToString ();
	}

	// Use this for initialization
	public void UpdateScore() {
		int nBlocks = GameObject.FindGameObjectsWithTag ("block").Length;
		if (nBlocks == 1) {
			Time.timeScale = 0f;
			winSFX.PlayOneShot(winClip);
			t.text = "you win!";
		} else {
			t.text = (nBlocks-1).ToString ();
		}
	}
}
