using UnityEngine;
using System.Collections;

public class Quest1 : QuestRepository{
	MenuManager menu;
	public Transform QuestWindow;
	InventoryData inv;
	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
		inv = GetComponent<InventoryData> ();
		InventoryData.OnChange += InvChanged;
		base.AddQuest ("Quest1");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Quest1s(){
		//Debug.Log ("YUp");
		if (base.GetQuestData ("quest1") == "unbegun")
			base.SetCurrentQuestStatus ("Not Started");
		else
		base.SetCurrentQuestStatus(base.GetQuestData("quest1"));
	}

	public void OpenWindow (){
		if (!menu.IsWindowOpen()) {
			menu.OpenCustomWindow (QuestWindow);
			base.SetCurrentQuest ("Quest1");
			base.SetCurrentGameObject (gameObject);
		} else {
			menu.CloseWindow();
		}
	}

	public void InvChanged(){
		if (inv.HasItem ("Book")) {
			base.SetQuestData("quest1", "book");
		}
	}
}
