using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Reflection;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	Transform content;
	public Text item;
	GameObject names;
	public Text questStatus;

	// Use this for initialization
	void Start () {
		questStatus = GameObject.Find ("QuestStatus").GetComponent<Text>();
		names = GameObject.Find("InvNames");
		DrawInv ();
		InventoryData.OnChange += UpdateInv;
	}

	void UpdateInv () {
		if (MenuManager.currentWindowName.Equals("Inventory") && MenuManager.windowOpen) {
			names = GameObject.Find("InvNames");
			if (names != null && names.transform.childCount > 0) {
				var children = new List<GameObject> ();
				foreach (Transform child in names.transform)
					children.Add (child.gameObject);
				children.ForEach (child => Destroy (child));
			}
			DrawInv();
		}
	}

	public void RemoveItem(string name){
		DestroyObject (GameObject.Find (name + "1"));
	}

    public void DrawInv() {
        if (names != null) {
            foreach (object entry in InventoryData.items) {
                Text newItem = Instantiate(item);
                newItem.transform.SetParent(names.transform, false);
                newItem.text = " " + ((InventoryData.itemCount[entry] > 1) ? ("" + InventoryData.itemCount[entry] + "x ") : ("")) + entry.ToString() + ((InventoryData.compareItems(InventoryData.getEquipped(), entry)) ? (" \u25cf") : (""));
                newItem.name = entry.ToString() + "1";
                newItem.GetComponent<ItemExecution>().item = entry;
            }
        questStatus.text = JsonFile.save.PlayerData.currentQuest + ((!JsonFile.save.PlayerData.currentQuest.Equals("")) ? (": \n\n") : ("")) + QuestDictionary.GetUpdate(JsonFile.save.PlayerData.currentQuest);
        }
	}
}
