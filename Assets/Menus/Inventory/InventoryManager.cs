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
	public Transform names;
	public Transform numbers;
	public Text questStatus;

	// Use this for initialization
	void Start () {
		questStatus = GameObject.Find ("QuestStatus").GetComponent<Text>();
		DrawInv ();
		InventoryData.OnChange += UpdateInv;
	}

	void UpdateInv () {
		if (MenuManager.currentWindowName.Equals("Inventory")) {
			if (names.childCount > 0) {
				var children = new List<GameObject> ();
				foreach (Transform child in names)
					children.Add (child.gameObject);
				children.ForEach (child => Destroy (child));
			}
			if (numbers.childCount > 0) {
				var children2 = new List<GameObject> ();
				foreach (Transform child2 in numbers)
					children2.Add (child2.gameObject);
				children2.ForEach (child2 => Destroy (child2));
			}
			DrawInv();
		}
	}

	public void RemoveItem(string name){
		DestroyObject (GameObject.Find (name + "1"));
		DestroyObject (GameObject.Find (name + "2"));
	}

	public void DrawInv(){
		foreach (var entry in InventoryData.inventory) {
			Text newItem = Instantiate (item);
			newItem.transform.SetParent (names, false);
			newItem.text = "  " + entry.Key;
			newItem.name = entry.Key + "1";
		
			Text newNum = Instantiate (num);
			newNum.transform.SetParent (numbers, false);
			newNum.text = entry.Value.ToString () + "  ";
			newNum.name = entry.Key + "2";
		}
		if (QuestRepository.questObject != null)
			QuestRepository.questObject.SendMessage (QuestRepository.currentQuest + "s");
		questStatus.text = QuestRepository.currentQuest + "\n" + QuestRepository.currentQuestStatus;

	}
}
