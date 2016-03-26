using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GenericChest : MonoBehaviour, Inventory {
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
    public void AddObject(object obj, int num) {
        items.Add(obj);
        itemCount[obj] = num;
    }

	public void SaveInventory() {
		if (JsonFile.save.Inventories.InventoryData.ContainsKey(inventoryIdentifier)) {
			JsonFile.save.Inventories.InventoryData[inventoryIdentifier] = new Save.inventoryData();
		} else {
			JsonFile.save.Inventories.InventoryData.Add(inventoryIdentifier, new Save.inventoryData());
		}
		if (items.Count > 0) {
			int y = 0;
			int[] count = new int[itemCount.Count];
			foreach (object e in items) {
				JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryItems.Insert(y, SaveData.SerializeObject(e));
				count[y] = itemCount[e];
				y++;
			}
			JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryCount = count;
			JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryLength = items.Count;
			JsonFile.WriteData();
		} else {
			JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryLength = 0;
			JsonFile.WriteData();
		}
	}
	public void GetInventory() {
		items.Clear();
		itemCount.Clear();
		if (JsonFile.save.Inventories.InventoryData.ContainsKey(inventoryIdentifier)){
			int invLength = JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryLength;
				int[] count = JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryCount;
				if (invLength > 0 && count.Length > 0) {
					int i = 0;
					object[] invItems = JsonFile.save.Inventories.InventoryData[inventoryIdentifier].inventoryItems.ToArray();
					foreach (object itm in invItems) {
						AddObject(SaveData.DeSerializeObject((string)itm), count[i]);
					}
				}
		}
	}
	
	void ResetInv(){
		Enabled = true;
		try {
			JsonFile.save.Inventories.inventoryEnabled[inventoryIdentifier] = true;
		} catch (Exception) {}
		items.Clear ();
		itemCount.Clear();
		Start ();
	}

	void Start () {
		if (this != null) {
			menu = GameObject.Find("Main Canvas").GetComponent<MenuManager>();
			if (JsonFile.save.Inventories.inventoryEnabled.ContainsKey(inventoryIdentifier)) {
				Enabled = JsonFile.save.Inventories.inventoryEnabled[inventoryIdentifier];
			} else {
				JsonFile.save.Inventories.inventoryEnabled.Add(inventoryIdentifier, true);
			}
			if (Enabled) {
				CreateItemObject itmobj = GetComponent<CreateItemObject>();
				if (itmobj != null) {
					itmobj.AddItems();
					Enabled = false;
					JsonFile.save.Inventories.inventoryEnabled[inventoryIdentifier] = Enabled;
					SaveData.queueSave = true;
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
				TransferItem(entry);
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
