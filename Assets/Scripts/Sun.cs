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

	void Update () {
		if (DayCycle.hours >= 18 && DayCycle.hours < 20) {
			sun.intensity -= (sun.intensity > nightBrightness) ? (sunRate) : (0);
		} else if (DayCycle.hours >= 6 && DayCycle.hours < 8) {
			sun.intensity += (sun.intensity < dayBrightness) ? (sunRate) : (0);
		} else if (DayCycle.hours >= 8 && DayCycle.hours < 18) {
			sun.intensity = dayBrightness;
		} else if (DayCycle.hours >= 20 || DayCycle.hours < 6) {
			sun.intensity = nightBrightness;
		}
	}
}
