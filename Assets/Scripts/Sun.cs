using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
	Light sun;
	float sunRate = .0001f;
	float nightBrightness = .6f;
	float dayBrightness = 1.6f;
	// Use this for initialization
	void Start () {
		sun = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (DayCycle.hours >= 19 && DayCycle.hours < 21) {
			sun.intensity -= (sun.intensity > nightBrightness) ? (sunRate) : (0);
		} else if (DayCycle.hours >= 6 && DayCycle.hours < 8) {
			sun.intensity += (sun.intensity < dayBrightness) ? (sunRate) : (0);
		} else if (DayCycle.hours >= 8 && DayCycle.hours < 19) {
			sun.intensity = dayBrightness;
		} else if (DayCycle.hours >= 21 || DayCycle.hours < 6) {
			sun.intensity = nightBrightness;
		}
	}
}
