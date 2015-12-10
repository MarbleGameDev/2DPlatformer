﻿using UnityEngine;
using System.Collections;

public class SampleQuest : MonoBehaviour, IQuest {
	static string state = "blank";
	NotificationManager noteMan;
	public string StatusUpdate(){ 	//Gets called any time the game wants to know what the status of the quest is, also when the quest is first started
		switch (state){ 	//switch between the set states
		case "blank": 	//blank state can be used as a startup function
			noteMan = GameObject.Find("Notification Canvas").GetComponent<NotificationManager>();
			InventoryData.OnChange += InvUpdate; 	//start listening to inventory updates
			noteMan.AddNofication("Quest Started", "Started SampleQuest"); 	//Adding notification that the quest started
			state = "Pick up Diary (0/1)";
			break;
		case "Pick up Diary (0/1)":
			break;
		case "Pick up Diary (1/1)":
			state = "Finished";
			noteMan.AddNofication("Quest Complete", "Finished SampleQuest"); 	//adding notification that the quest is finished
			InventoryData.OnChange -= InvUpdate; 	//stop listening to inventory updates
			break;
		}
		return state; 	//Return a string stating the status of the quest
	}

	void InvUpdate(){ 	//Function for inventory updates, setup above
		if (InventoryData.HasItem ("Diary")) { 	//Checking the inventory for an item added
			state = "Pick up Diary (1/1)";
			StatusUpdate(); 	//run the function to update to any new changes to the quest state
		}
	}
}
