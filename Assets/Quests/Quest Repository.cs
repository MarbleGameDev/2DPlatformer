using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestRepository : MonoBehaviour{

	public static Dictionary<string, int> quests;

	void Awake(){
		quests = new Dictionary<string, int> ();
	}

	public void AddQuest(string name){
		quests.Add (name, 0);
		if (Settings.debug)
		Debug.Log ("Quest added: " + name);
	}

	public int GetQuestData(string name){
		int temp;
		bool tayest = quests.TryGetValue(name, out temp);
		return temp;
	}

	public void SetQuestData(string name, int num){
		quests [name] = num;
	}

}
