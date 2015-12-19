using UnityEngine;
using System.Collections;

public class RegisterQuests : MonoBehaviour {
	static bool hasRegistered = false;
	// Use this for initialization
	void Start () {
		if (hasRegistered == false) {  	//Name entered in the string here is the name displayed in game
			SaveData.ResetQuests += QuestDictionary.Reset;
			QuestDictionary.Quests.Add ("SampleQuest", () => new SampleQuest());
			SaveData.ResetQuests += SampleQuest.Reset;
			QuestDictionary.Quests.Add ("Rebuild Town Bridge", () => new RebuildBridge());
			SaveData.ResetQuests += RebuildBridge.Reset;
			hasRegistered = true;
		}
	}
}
