using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	public int blockHealth;
	public Material health2Mat;
	public Material health1Mat;

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
