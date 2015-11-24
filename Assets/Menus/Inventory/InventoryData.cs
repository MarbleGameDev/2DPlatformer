using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryData : MonoBehaviour {

	public static Dictionary<string, int> inventory;
	// Use this for initialization
	void Start () {
		inventory.Add ("Key", 1);
		inventory.Add ("Swag", 1);
		inventory.Add ("Potion", 4);
		inventory.Add ("Key1", 1);
		inventory.Add ("Key2", 1);
		inventory.Add ("Key3", 1);
		inventory.Add ("Key4", 1);
		inventory.Add ("Key5", 1);
		inventory.Add ("Key6", 1);
		inventory.Add ("Key7", 1);
		inventory.Add ("Key8", 1);
		inventory.Add ("Key9", 1);
		inventory.Add ("Key99", 1);
		inventory.Add ("Key0", 1);
		inventory.Add ("Key11", 1);
		inventory.Add ("Key12", 1);
		inventory.Add ("Key13", 1);
		inventory.Add ("Key14", 1);
		inventory.Add ("Key15", 1);
		inventory.Add ("Key16", 1);
	}
	void Awake (){
		inventory = new Dictionary<string, int> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
