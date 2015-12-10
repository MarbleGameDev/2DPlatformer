using UnityEngine;
using System.Collections;

public class RegisterQuests : MonoBehaviour {
	static bool hasRegistered = false;
	// Use this for initialization
	void Start () {
		if (hasRegistered == false) {
			QuestDictionary.Quests.Add ("SampleQuest", () => new SampleQuest());
			hasRegistered = true;
		}
	}
}
