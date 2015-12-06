using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GenericChest : MonoBehaviour {
	MenuManager menu;
	public Transform ChestWindow;
	public Text item;
	public Text num;
	Transform names;

	public string[] itemsNames; 	//Must be of the same Length
	public int[] itemQuantities;

	public bool empty = false;

	public static Dictionary<string, int> inventory;

	// Use this for initialization
	void Awake (){
		inventory = new Dictionary<string, int> ();
	}

	void Start () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
		for (int i = 0; i < itemsNames.Length; i++) {
			if (itemQuantities[i] > 0){
				inventory.Add (itemsNames[i], itemQuantities[i]);
			}
		}
		if (itemsNames.Length == 0 || itemQuantities.Length == 0) {
			empty = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenWindow (){
		if (!menu.IsWindowOpen ()) {
			menu.OpenCustomWindow (ChestWindow);
			SetupItems();
		} else if (menu.IsWindowOpen() && empty) {
			menu.CloseWindow ();
		} else if (menu.IsWindowOpen() && !empty){
			foreach (var entry in inventory) {
				InventoryData.AddItem (entry.Key, entry.Value);
				RemoveItem(entry.Key);
			}
			inventory.Clear();
		}
	}

	private void SetupItems(){

		names = GameObject.Find ("InvNames").transform;

		foreach (var entry in inventory) {
			Text newItem = Instantiate(item);
			newItem.transform.SetParent(names, false);
			newItem.text = " " + ((entry.Value > 1) ? ("" + entry.Value.ToString() + "x ") : ("")) + entry.Key + ((entry.Key.Equals(InventoryData.EquippedItem)) ? (" \u25cf") : (""));
			newItem.name = entry.Key + "1";
		}
	}

	public void RemoveItem(string name){
		DestroyObject (GameObject.Find (name + "1"));
		empty = true;
	}

}
