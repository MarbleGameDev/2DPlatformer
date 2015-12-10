using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Reflection;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	Transform content;
	public Text item;
	public Text num;
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
			if (names.gameObject != null || names.transform.childCount > 0) {
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

	public void DrawInv(){
		foreach (var entry in InventoryData.inventory) {
			Text newItem = Instantiate (item);
			newItem.transform.SetParent (names.transform, false);
			newItem.text = " " + ((entry.Value > 1) ? ("" + entry.Value.ToString() + "x ") : ("")) + entry.Key + ((entry.Key.Equals(InventoryData.EquippedItem)) ? (" \u25cf") : (""));
			newItem.name = entry.Key + "1";

		}
		questStatus.text = QuestDictionary.currentQuest + "\n" + QuestDictionary.GetUpdate(QuestDictionary.currentQuest);

	}
}
