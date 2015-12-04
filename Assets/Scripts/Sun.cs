using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
	Light sun;
	// Use this for initialization
	void Start () {
		sun = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Literal Hell, should probably find a better solution later that doesn't increase rate at beginning or end
		sun.intensity = (DayCycle.hours >= 12) ? ((float)(0.5f + Mathf.Sqrt(((24 - DayCycle.hours) / 12f) - ((!(DayCycle.hours == 23 && DayCycle.minutes >= 8.3)) ? ((float)DayCycle.minutes) / 100f : (0.08f)) ))) : ((float)(0.5f + Mathf.Sqrt((DayCycle.hours / 12f) + ((float)DayCycle.minutes) / 100f)));
	}
}
