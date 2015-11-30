using UnityEngine;
using System.Collections;

public class RegisterItems : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ItemDictionary.itemList.Add("Diary", ()=> new Diary());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
