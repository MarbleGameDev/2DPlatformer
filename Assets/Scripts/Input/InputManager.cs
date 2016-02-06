using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void KeyReset(){
		SaveData.Left = "a";
		SaveData.Right = "d";
		SaveData.Up = "w";
		SaveData.Down = "s";
		SaveData.Inventory = "tab";
		SaveData.Interact = "e";
		SaveData.Skip = "space";
		SaveData.Minimap = "left shift";
		SaveData.StoreData ();
	}

	public void InspectorReset(){
		KeyReset ();
	}

	public static void SetKey(string name, string key){
		switch (name) {
		case "Left":
		case "left":
			SaveData.Left = key;
			break;
		case "Right":
		case "right":
			SaveData.Right = key;
			break;
		case "Up":
		case "up":
			SaveData.Up = key;
			break;
		case "Down":
		case "down":
			SaveData.Down = key;
			break;
		case "Interact":
		case "interact":
			SaveData.Interact = key;
			break;
		case "Inventory":
		case "inventory":
			SaveData.Inventory = key;
			break;
		case "Skip":
		case "skip":
			SaveData.Skip = key;
			break;
		case "Minimap":
		case "minimap":
			SaveData.Minimap = key;
			break;
		}
		SaveData.StoreData ();
	}
	public static string GetKey(string name){
		string key = "f12";
		switch (name) {
		case "Left":
		case "left":
			key = SaveData.Left;
			break;
		case "Right":
		case "right":
			key = SaveData.Right;
			break;
		case "Up":
		case "up":
			key = SaveData.Up;
			break;
		case "Down":
		case "down":
			key = SaveData.Down;
			break;
		case "Interact":
		case "interact":
			key = SaveData.Interact;
			break;
		case "Inventory":
		case "inventory":
			key = SaveData.Inventory;
			break;
		case "Skip":
		case "skip":
			key = SaveData.Skip;
			break;
		case "Minimap":
		case "minimap":
			key = SaveData.Minimap;
			break;
		}
		if (key == null || key.Equals ("") || key.Equals(" ")) {
			key = "f12";
		}
		return key;
	}

}
