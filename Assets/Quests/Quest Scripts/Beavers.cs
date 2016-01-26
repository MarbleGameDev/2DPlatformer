using UnityEngine;
using System.Collections;

public class Beavers : MonoBehaviour, IQuest {
	static string state = ""; 	
	public string StatusUpdate(){ 
		if (state.Equals ("")) {
			state = PlayerPrefs.GetString("Beavers", "blank");
		}
		PlayerPrefs.SetString ("Beavers", state); 
		switch (state){ 
		case "blank": 
			InventoryData.OnChange += InvUpdate; 
			NotificationManager.AddNotification("Quest Started", "A mystery with wooden proportions"); 
			state = "Goto the scene of the crim";
			break;
		case "Goto the scene of the crime":
			break;

			//stuff happens here... WIP

		case "Return to forester":
			break;
		}
		return state; 
	}
	
	void InvUpdate(){ 
	
	
	}
	
	public void Reset(){

		//Debug.Log("Reset");
		state = "blank";
		PlayerPrefs.SetString("Beavers", "blank");

	}

	public void Setstate(string state_set){

		state = state_set;
		StatusUpdate();

	} 
}
