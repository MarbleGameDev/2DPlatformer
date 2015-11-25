using UnityEngine;
using System.Collections;

public class Quest1 : QuestRepository{
	MenuManager menu;
	public Transform QuestWindow;
	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
		base.AddQuest ("quest1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenWindow (){
		if (!menu.IsWindowOpen()) {
			menu.OpenCustomWindow (QuestWindow);
		} else {
			menu.CloseWindow();
		}
	}
}
