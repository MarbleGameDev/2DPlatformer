#pragma strict
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

	public string[] itemsNames; 	//Must be the same Length
	public int[] itemQuantities; 	//as this

	public string inventoryIdentifier; 	//Unique identifier
	public bool Enabled = true;

	public bool empty = false;
	public Dictionary<string, int> inventory = new Dictionary<string, int> ();

	void Awake (){
		SaveData.ResetInv += ResetInv;
	}

	void ResetInv(){
		Enabled = true;
		PlayerPrefsX.SetBool (inventoryIdentifier, true);
		inventory.Clear ();
		Start ();
	}

	void Start () {
		Enabled = PlayerPrefsX.GetBool (inventoryIdentifier, true);
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
		if (Enabled == true){
			for (int i = 0; i < itemsNames.Length; i++) {
				if (itemQuantities [i] > 0) {
					inventory.Add (itemsNames [i], itemQuantities [i]);
				}
			}
			empty = false;
			if (itemsNames.Length == 0 || itemQuantities.Length == 0) {
				empty = true;
			}
		} else {
			empty = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OpenWindow (){
		if (!MenuManager.windowOpen) {
			menu.OpenCustomWindow (ChestWindow);
			if (empty == false)
				SetupItems();
		} else if (MenuManager.windowOpen && empty) {
			menu.CloseWindow ();
		} else if (MenuManager.windowOpen && !empty){
			foreach (var entry in inventory) {
				InventoryData.AddItem (entry.Key, entry.Value);
				RemoveItem(entry.Key);
			}
			Enabled = false;
			inventory.Clear();
			PlayerPrefsX.SetBool(inventoryIdentifier, Enabled);
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
