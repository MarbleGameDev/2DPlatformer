using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GenericChest : MonoBehaviour {
	MenuManager menu;
	public Transform ChestWindow;
	public Text item;
	Transform names;
    public Dictionary<object, int> itemCount = new Dictionary<object, int>();
    public List<object> items = new List<object>();

    public string inventoryIdentifier; 	//Unique identifier
	public bool Enabled = true;

	public bool empty = false;

	void Awake (){
		SaveData.ResetInv += ResetInv;
	}
    public void AddItem(object obj, int num) {
        items.Add(obj);
        itemCount[obj] = num;
    }

	public void SaveInventory() {
		if (items.Count > 0) {
			int y = 0;
			int[] count = new int[itemCount.Count];
			foreach (object e in items) {
				PlayerPrefsSerializer.Save(inventoryIdentifier + y, e);
				count[y] = itemCount[e];
				y++;
			}
			PlayerPrefsX.SetIntArray(inventoryIdentifier + "Count", count);
			PlayerPrefs.SetInt(inventoryIdentifier + "Length", items.Count);
			PlayerPrefs.Save();
		} else {
			PlayerPrefs.SetInt(inventoryIdentifier + "Length", 0);
			PlayerPrefs.Save();
		}
	}
	public void GetInventory() {
		items.Clear();
		itemCount.Clear();
		int invLength = PlayerPrefs.GetInt(inventoryIdentifier + "Length", 0);
		var count = PlayerPrefsX.GetIntArray(inventoryIdentifier + "Count", 0, 0);
		if (invLength > 0 && count.Length > 0) {
			for (int i = 0; i < invLength; i++) {
				AddItem(PlayerPrefsSerializer.Load(inventoryIdentifier + i), count[i]);
			}
			empty = false;
		} else {
			empty = true;
		}
	}

	void ResetInv(){
		Enabled = true;
		PlayerPrefsX.SetBool (inventoryIdentifier, Enabled);
		items.Clear ();
		itemCount.Clear();
		Start ();
	}

	void Start () {
		if (this != null) {
			menu = GameObject.Find("Main Canvas").GetComponent<MenuManager>();
			Enabled = PlayerPrefsX.GetBool(inventoryIdentifier, true);
			if (Enabled) {
				Debug.Log(inventoryIdentifier);
				CreateItemObject itmobj = GetComponent<CreateItemObject>();
				if (itmobj != null) {
					itmobj.AddItems();
					Enabled = false;
					PlayerPrefsX.SetBool(inventoryIdentifier, Enabled);
					PlayerPrefs.Save();
				}
				SaveInventory();
			} else {
				GetInventory();
			}
		}
	}

	public void OpenWindow (){
		if (!MenuManager.windowOpen) {
			menu.OpenCustomWindow (ChestWindow);
			if (empty == false)
				SetupItems();
		} else if (MenuManager.windowOpen && empty) {
			menu.CloseWindow ();
		} else if (MenuManager.windowOpen && !empty){
			object[] entries = items.ToArray();
			foreach (object entry in entries) {
				InventoryData.AddItem (entry, itemCount[entry]);
				RemoveItem(entry);
			}
			items.Clear();
			itemCount.Clear();
			empty = true;
		}
	}

	private void SetupItems(){

		names = GameObject.Find ("InvNames").transform;

		if (names != null) {
			foreach (object entry in items) {
				Text newItem = Instantiate(item);
				newItem.transform.SetParent(names.transform, false);
				newItem.text = " " + ((itemCount[entry] > 1) ? ("" + itemCount[entry] + "x ") : ("")) + entry.ToString();
				newItem.name = entry.ToString() + "2";
				ContainerTransfer cont = newItem.GetComponent<ContainerTransfer>();
				cont.container = this.transform;
				cont.item = entry;
			}
		}
	}

	public void RemoveItem(object obj){
		DestroyObject (GameObject.Find (obj.ToString() + "2"));
		items.Remove (obj);
		itemCount.Remove(obj);
		if (items.Count == 0)
			empty = true;
	}

	public void TransferItem(object obj) {
		InventoryData.AddItem(obj, itemCount[obj]);
		RemoveItem(obj);
		SaveInventory();
	}

}
