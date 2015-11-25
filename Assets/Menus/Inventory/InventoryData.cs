using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryData : MonoBehaviour {

	public static Dictionary<string, int> inventory;
	// Use this for initialization
	void Start () {

	}
	void Awake (){
		inventory = new Dictionary<string, int> ();

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
		inventory.Add ("Key69", 1);
		inventory.Add ("Key79", 1);
		inventory.Add ("Key89", 1);
		inventory.Add ("Key95", 1);
		inventory.Add ("Key93", 1);
		inventory.Add ("Key61", 1);
		inventory.Add ("Key71", 1);
		inventory.Add ("Key81", 1);
		inventory.Add ("Key91", 1);
		inventory.Add ("Key90", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool HasItem(string item){
		return inventory.ContainsKey (item);
	}

	public void AddItem (string name, int number){
		inventory.Add (name, number);
	}
}
