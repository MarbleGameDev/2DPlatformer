using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestRepository : MonoBehaviour{

	public static Dictionary<string, string> quests = new Dictionary<string, string> ();
	public static GameObject questObject;
	public static string currentQuest;
	public static string currentQuestStatus;

	void Awake(){
	}

	public void AddQuest(string name){
		quests.Add (name, "unbegun");
		if (Settings.debug) {
			//Debug.Log ("Quest added: " + name);
		}
	}

	public string GetQuestData(string name){
		string temp;
		bool tayest = quests.TryGetValue(name, out temp);
		return temp;
	}

	public void SetQuestData(string name, string num){
		quests [name] = num;
	}

	public void SetCurrentQuest(string name){
		currentQuest = name;
	}
	public void SetCurrentQuestStatus(string status){
		currentQuestStatus = status;
	}
	public void SetCurrentGameObject(GameObject obj){
		questObject = obj;
	}
}
