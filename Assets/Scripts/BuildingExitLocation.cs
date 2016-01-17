using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingExitLocation : MonoBehaviour {
	public static string location;
	static Dictionary<string, Vector2> locations = new Dictionary<string, Vector2>();
	void Awake(){
		if (locations.Count == 0) {
			locations.Add ("villageRoom1", new Vector2 (-40f, 20.1f));
			locations.Add ("villageSpawn", new Vector2 (0f, 0f));
		}
	}
	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null && location != null)
			player.transform.position = locations [location];
	}
	
	public static void SetBuilding(string name){
		location = name;
	}
}
