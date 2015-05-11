using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public int blockHealth;
	public Material health2Mat;
	public Material health1Mat;
	public GameObject[] powerUps;
	public float powerUpChance;

	private Renderer r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		blockHealth -= 1;

		if (Random.Range (0f, 1f) < powerUpChance) {
			int type = Random.Range(0, 2);
			Instantiate(powerUps[type], transform.position, Quaternion.Euler(90f, 0f, 0f));
		}

		switch (blockHealth)
		{
		case 0:
			Destroy (this.gameObject);
			break;
		case 1:
			r.material = health1Mat;
			break;
		case 2:
			r.material = health2Mat;
			break;
		default:
			Debug.LogError ("Unexpected block health integer!");
			break;
		}
	}
}
