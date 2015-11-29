using UnityEngine;
using System.Collections;

public class CandleFlicker : MonoBehaviour {
	Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		InvokeRepeating ("Light", 0f, .25f);
	}
	
	// Update is called once per frame
	void Light () {
		float num = Random.value;
		float direction = Random.value;
		if (direction <= 0.5f && light.intensity < 1.5f && light.intensity > .75f) {
			light.intensity = Mathf.SmoothStep (light.intensity, light.intensity - (num / 2), 0.25f);
		} else if (direction > 0.5f && light.intensity < 1.5f && light.intensity > .75f) {
			light.intensity = Mathf.SmoothStep (light.intensity, light.intensity + (num / 2), 0.25f);
		} else {
			light.intensity = Mathf.SmoothStep (light.intensity, 1, 0.25f);
		}
	}
}
