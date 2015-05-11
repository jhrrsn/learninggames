using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {

	public TextAsset levelData;
	public GameObject[] assets;

	// Use this for initialization
	void Start () {
		string text = levelData.text;
		string[] lines = text.Split ('\n');
		for (int i = 0; i < lines.Length; i++) {
			string[] items = lines[i].Split(',');
			for (int j = 0; j < items.Length; j++) {
				if (!string.IsNullOrEmpty(items[j])) {
					SpawnAsset(int.Parse(items[j]), j, i);
				}
			}
		}
	}
	
	void SpawnAsset(int key, int x, int y) {
		Vector2 pos = new Vector2 (x, -y);
		if (key != 1)
			Instantiate (assets[key], pos, Quaternion.identity);
	}
}
