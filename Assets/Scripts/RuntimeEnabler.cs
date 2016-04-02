using UnityEngine;
using System.Collections.Generic;

public class RuntimeEnabler : MonoBehaviour {
	public List<GameObject> gameobjects;
	// Use this for initialization
	void Start () {
		foreach (GameObject g in gameobjects) {
			g.SetActive(true);
		}
	}
	
}
