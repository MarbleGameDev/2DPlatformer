using UnityEngine;
using System.Collections;

public class RegisterItems : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ItemDictionary.itemList.Add ("Diary", ()=> new Diary());
		ItemDictionary.itemList.Add ("Sword", ()=> new Sword());
		ItemDictionary.itemList.Add ("Hands", () => new Hands ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
