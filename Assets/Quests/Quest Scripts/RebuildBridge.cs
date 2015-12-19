﻿using UnityEngine;
using System.Collections;

public class RebuildBridge : MonoBehaviour, IQuest {
	static string state = ""; 	//Store the Data to PlayerPrefs at some point
	public string StatusUpdate(){ 	//Gets called any time the game wants to know what the status of the quest is, also when the quest is first started
		if (state.Equals ("")) {
			state = PlayerPrefs.GetString("RebuildBridge", "blank"); 	//if the file is just initialized, read the data from disk, default to "blank" if it's the first time
		}
		PlayerPrefs.SetString ("RebuildBridge", state); 	//Store the data again in case it changes
		switch (state){ 	//switch between the set states
		case "blank": 	//blank state can be used as a startup function
			InventoryData.OnChange += InvUpdate; 	//start listening to inventory updates
			NotificationManager.AddNotification("Quest Started", "Rebuild Town Bridge"); 	//Adding notification that the quest started
			state = "Talk to carpenter";
			break;
		case "Talk to carpenter":
			break;
		case "Talked to carpenter":
			break;
		case "Goto Forester":
			break;
		case "Convince forester to give wood":
			break;
		case "Bring wood back to carpenter":
			break;
		case "Get tools from carpenters house":
			break;
		case "Bring tools back to carpenter":
			break;
		case "wait until midnight for bridge to be built":
			break;
			state = "Finished";
			NotificationManager.AddNotification("Quest Complete", "Rebuild Town Bridge"); 	//adding notification that the quest is finished
			InventoryData.OnChange -= InvUpdate; 	//stop listening to inventory updates
			PlayerPrefs.Save(); 	//Writes all data changes to disk just in case
			break;
		}
		return state; 	//Return a string stating the status of the quest
	}
	
	void InvUpdate(){ 	//Function for inventory updates, setup above

	}
	void PosUpdate(){

	}

	public static void Reset(){
		//Debug.Log("Reset");
		state = "blank";
		PlayerPrefs.SetString("SampleQuest", "blank");
	}

}


//First step of the quest is talking to a carpenter right next to the destroyed bridge
//The carpenter says that his stache of wooden resources hasnt arived yet and that you will have to talk to the forestry guy.
//He wants you to bring him some wood forestry shop nearby. (note: he wanted to get the caravan over the forestry shop because he fucking hates that dude and wants you to do it so he doesnt get embarresed.)
//You go to the foresters shop and you do (place something cool here) and then you get four bundles of high quality wood.
// bring the wood back and they will work until midnight