using UnityEngine;
using System.Collections;

public class RegisterQuests : MonoBehaviour {
	static bool hasRegistered = false;
	// Use this for initialization
	void Start () {
		if (hasRegistered == false) {  	//Name entered in the string here is the name displayed in game
            //Reset function no longer needs to be registered
			QuestDictionary.Quests.Add ("SampleQuest", () => new SampleQuest());
			QuestDictionary.Quests.Add ("Rebuild Town Bridge", () => new RebuildBridge());
			QuestDictionary.Quests.Add ("A mystery of Wooden Proportions", () => new Beavers());
			hasRegistered = true;
		}
	}
}
