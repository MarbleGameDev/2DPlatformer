using UnityEngine;
using System.Collections;

public class RebuildBridge : MonoBehaviour, IQuest {
	static string state = ""; 	//Store the Data to PlayerPrefs at some point
	static bool firstEnter = false;
	static bool[] items = new bool[]{ false, false, false};	//Planks, Tools, Cider
	static RebuildBridge() {	//Executes at the beginning of the game
		InventoryData.OnChange += InvUpdate;    //start listening to inventory updates
	}

	public string StatusUpdate(){   //Gets called any time the game wants to know what the status of the quest is, also when the quest is first started
		if (state.Equals("")) {
			if (JsonFile.save.Quests.QuestData.ContainsKey("RebuildBridge")) {	//If the quest data entry exists in the data read from file
				state = (string)JsonFile.save.Quests.QuestData["RebuildBridge"][0];
				items[0] = (bool)JsonFile.save.Quests.QuestData["RebuildBridge"][1];	//Retrieve data from object array at the index of the quest string
				items[1] = (bool)JsonFile.save.Quests.QuestData["RebuildBridge"][2];
				items[2] = (bool)JsonFile.save.Quests.QuestData["RebuildBridge"][3];
			} else {
				state = "blank";
				JsonFile.save.Quests.QuestData.Add("RebuildBridge", new object[] { state, false, false, false });     //New blanket array if one does not exist yet with default valuess
				SaveData.queueSave = true;	//Force a data write
			}
		}
		switch (state){ 	//switch between the set states
		    case "blank":
			    break;
			case "blank2":
				break;
		    case "Styoit":
			    state = "Collected: ";
			    NotificationManager.AddNotification("Quest Started", "Rebuild Town Bridge"); //Adding notification that the quest started
                QuestDictionary.SetCurrent("Rebuild Town Bridge");
			    break;
			case "Collected: ":
				break;
		    case "Solve the mystery of foresters wood":
			    // Place for second quest that has to do with beavers
			    break;
		    case "wait until midnight for bridge to be built":
			    break;
		    case "quest finished":
			    state = "Finished";
			    NotificationManager.AddNotification("Quest Complete", "Rebuild Town Bridge");   //adding notification that the quest is finished
			    break;
		}
		if (state.Equals("Collected: ")) {	//Create dynamic list of items
			state += ("\nWood: " + items[0] + "\nTools: " + items[1] + "\nCider: " + items[2]);
		}
		bool changed = false;
		if (!state.Equals((string)JsonFile.save.Quests.QuestData["RebuildBridge"][0])) {
			JsonFile.save.Quests.QuestData["RebuildBridge"][0] = state;
			changed = true;
		}
		if (items[0] != ((bool)JsonFile.save.Quests.QuestData["RebuildBridge"][1])) {
			JsonFile.save.Quests.QuestData["RebuildBridge"][1] = items[0];
			changed = true;
		}
		if (items[1] != ((bool)JsonFile.save.Quests.QuestData["RebuildBridge"][2])) {
			JsonFile.save.Quests.QuestData["RebuildBridge"][1] = items[1];
			changed = true;
		}
		if (items[2] != ((bool)JsonFile.save.Quests.QuestData["RebuildBridge"][3])) {
			JsonFile.save.Quests.QuestData["RebuildBridge"][1] = items[2];
			changed = true;
		}
		if (changed)
			SaveData.queueSave = true;  //Writes all data changes to disk just in case
		return state; 	//Return a string stating the status of the quest
	}
	
	static void InvUpdate(){    //Function for inventory updates, setup above
		if (!state.Equals("Finished")) {
			//Check for the wood, tools, and cider in the inventory, set the boolean values
			if (InventoryData.HasItem(ItemDictionary.itemDict.GetItem("Planks"))) {
				items[0] = true;
			}
			if (InventoryData.HasItem(ItemDictionary.itemDict.GetItem("Cider"))) {
				items[1] = true;
			}
			if (InventoryData.HasItem(ItemDictionary.itemDict.GetItem("Tools"))) {
				items[2] = true;
			}
			QuestDictionary.GetUpdate("Rebuild Town Bridge");	//Update the status after new items
		}

	}
	void PosUpdate(){

	}


	public void StatUpdate(){
		StatusUpdate ();
	}

	public void Setstate(string state_set){
		state = state_set;
		StatusUpdate();
	}

	public void onFirstEnter(){
	
			
	
	}

	public void Reset() {
		state = "blank";
		if (JsonFile.save.Quests.QuestData.ContainsKey("RebuildBridge")) {	//Similar code as above to reset to default values
			JsonFile.save.Quests.QuestData["RebuildBridge"] = new object[] { state, false, false, false };
		} else {
			JsonFile.save.Quests.QuestData.Add("RebuildBridge", new object[] { state, false, false, false });
		}
		SaveData.queueSave = true;

	}

}


//First step of the quest is talking to a carpenter right next to the destroyed bridge
//The carpenter says that his stache of wooden resources hasnt arived yet and that you will have to talk to the forestry guy.
//He wants you to bring him some wood forestry shop nearby. (note: he wanted to get the caravan over the forestry shop because he fucking hates that dude and wants you to do it so he doesnt get embarresed.)
//You go to the foresters shop and you do (place something cool here) and then you get four bundles of high quality wood.
// bring the wood back and they will work until midnight