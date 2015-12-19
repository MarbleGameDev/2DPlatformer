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
		SaveData.currentQuest = name;
		SaveData.StoreData ();
		GetUpdate (name);
	}

	public void InspectorSet(string name){
		SetCurrent (name);
	}

	public static void Reset(){
		SaveData.currentQuest = "";
	}
}
