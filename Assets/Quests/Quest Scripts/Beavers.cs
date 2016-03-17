using UnityEngine;
using System.Collections;

public class Beavers : MonoBehaviour, IQuest {
	public static string state = "";

	static Beavers() {    //Executes at the beginning of the game
		InventoryData.OnChange += InvUpdate;    //start listening to inventory updates
	}


	public string StatusUpdate(){ 
		if (state.Equals ("")) {
			if (JsonFile.save.Quests.QuestData.ContainsKey("Beavers")) {
				state = (string)JsonFile.save.Quests.QuestData["Beavers"][0];
			} else {
				state = "blank";
				JsonFile.save.Quests.QuestData.Add("Beavers", new object[] {state});
			}
		}
		switch (state){ 
		    case "blank": 
                break;
			case "blank2":
				break;
			case "bridge":
				break;
            case "stoiyt":
                NotificationManager.AddNotification("Quest Started", "A mystery with wooden proportions");
                QuestDictionary.SetCurrent("Beavers");
			    state = "Go to the scene of the crime";
			    break;
		    case "Go to the scene of the crime":
			    break;

			    //stuff happens here... WIP

		    case "Return to Desislav":
			    break;
			case "Finished":
				break;
		}
		return state; 
	}
	
	static void InvUpdate(){ 
	
	
	}
	
	public void Reset(){

		//Debug.Log("Reset");
		state = "blank";
		if (JsonFile.save.Quests.QuestData.ContainsKey("Beavers")) {
			JsonFile.save.Quests.QuestData["Beavers"][0] = state;
		} else {
			JsonFile.save.Quests.QuestData.Add("Beavers", new object[] {state});
		}

	}

	public void Setstate(string state_set){

		state = state_set;
		StatusUpdate();

	} 
}
