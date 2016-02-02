using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

	void ResetInv(){
		Enabled = true;
		PlayerPrefsX.SetBool (inventoryIdentifier, true);
		items.Clear ();
		itemCount.Clear();
		Start ();
		if (gameObject.GetComponent<CreateItemObject>() != null) {
			gameObject.GetComponent<CreateItemObject>().Start();
		}
	}

	void Start () {
		menu = GameObject.Find("Main Canvas").GetComponent<MenuManager>();
		Enabled = PlayerPrefsX.GetBool (inventoryIdentifier, true);
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
			Enabled = false;
			items.Clear();
			itemCount.Clear();
			PlayerPrefsX.SetBool(inventoryIdentifier, Enabled);
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

}
