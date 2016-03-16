using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuestDictionary : MonoBehaviour {
	public static Dictionary<string, Func<IQuest>> Quests = new Dictionary<string, Func<IQuest>>();
		
	public static string GetUpdate(string name){
		if (Quests.ContainsKey (name)) {
			return (Quests [name]) ().StatusUpdate ();
		} else {
			return "";
		}
	}

	public static void SetCurrent(string name){
		JsonFile.save.PlayerData.currentQuest = name;
		SaveData.queueSave = true;
		GetUpdate (name);
	}

	public void InspectorSet(string name){
		SetCurrent (name);
	}

	public static void Reset(){
		JsonFile.save.PlayerData.currentQuest = "";
        foreach (KeyValuePair<string, Func<IQuest>> quest in Quests) {
            (Quests[quest.Key])().Reset();
        }
	}
}
