using UnityEngine;
using System.Collections;

public class RegisterItems : MonoBehaviour {
	static bool hasRegistered = false;
	// Use this for initialization
	void Start () {
		if (hasRegistered == false) {
			ItemDictionary.itemList.Add ("Diary", () => new Diary ());
			ItemDictionary.itemList.Add ("Sword", () => new Sword ());
			ItemDictionary.itemList.Add ("Hands", () => new Hands ());
			hasRegistered = true;
		}
	}
}
