using UnityEngine;
using System.Collections;

public class Quest1 : QuestRepository{
	MenuManager menu; 	//Menu object declaration
	public Transform QuestWindow; 	//public window that shows up in inspector
	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> (); 	//Find the Menu Manager, necessary if you want to display a window
		InventoryData.OnChange += InvChanged; 	//Add the function name for a function to be called if the player inventory changes
		base.AddQuest ("Quest1"); 	//Add the quest to the game
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Quest1s(){ 	//The function with the same name as the class and quest will get called any time the game wants an update on the quest status
		//This is where you tell the game what's going on via the SetCurrentQuestStatus()
		//Any calculations as to the stage of the quest will go here
		if (base.GetQuestData ("quest1") == "unbegun")
			base.SetCurrentQuestStatus ("Not Started");
		else
		base.SetCurrentQuestStatus(base.GetQuestData("quest1"));
	}

	public void OpenWindow (){
		if (!menu.IsWindowOpen()) {
			menu.OpenCustomWindow (QuestWindow);
			base.SetCurrentQuest ("Quest1");
			base.SetCurrentGameObject (gameObject); 	//Stores the gameobject that the quest is attached to for later use
		} else {
			menu.CloseWindow();
		}
	}

	public void InvChanged(){
		if (InventoryData.HasItem ("Book")) {
			base.SetQuestData("quest1", "book");
		}
	}
}
