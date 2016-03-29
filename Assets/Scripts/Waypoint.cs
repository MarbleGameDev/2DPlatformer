using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Navigation.SetObj(gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnBecameInvisible() {
		Navigation.offScreen = true;
	}
	void OnBecameVisible() {
		Navigation.offScreen = false;
	}
}
