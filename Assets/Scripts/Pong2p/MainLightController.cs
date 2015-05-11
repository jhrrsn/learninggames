using UnityEngine;
using System.Collections;

public class MainLightController : MonoBehaviour {

	public float targetIntensity;
	public float rate;

	private bool lowerLights;
	private bool raiseLights;
	private Light mainLight;

	// Use this for initialization
	void Start () {
		mainLight = GetComponent<Light> ();
		lowerLights = false;
		raiseLights = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (mainLight.intensity <= 0) {
			mainLight.intensity = 0;
			lowerLights = false;
		} else if (mainLight.intensity >= targetIntensity) {
			mainLight.intensity = targetIntensity;
			raiseLights = false;
		}

		if (lowerLights) {
			mainLight.intensity -= rate;
		} else if (raiseLights) {
			mainLight.intensity += rate;
		}
	}

	public void DimLights () {
		lowerLights = true;
	}

	public void RaiseLights () {
		raiseLights = true;
	}
}
