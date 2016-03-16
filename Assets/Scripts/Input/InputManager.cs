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
		JsonFile.save.Controls.Left = "a";
		JsonFile.save.Controls.Right = "d";
		JsonFile.save.Controls.Up = "w";
		JsonFile.save.Controls.Down = "s";
		JsonFile.save.Controls.Inventory = "tab";
		JsonFile.save.Controls.Interact = "e";
		JsonFile.save.Controls.Skip = "space";
		JsonFile.save.Controls.Minimap = "left shift";
		JsonFile.WriteData();
	}

	public void InspectorReset(){
		KeyReset ();
	}

	public static void SetKey(string name, string key){
		switch (name) {
		case "Left":
		case "left":
				JsonFile.save.Controls.Left = key;
			break;
		case "Right":
		case "right":
				JsonFile.save.Controls.Right = key;
			break;
		case "Up":
		case "up":
				JsonFile.save.Controls.Up = key;
			break;
		case "Down":
		case "down":
				JsonFile.save.Controls.Down = key;
			break;
		case "Interact":
		case "interact":
				JsonFile.save.Controls.Interact = key;
			break;
		case "Inventory":
		case "inventory":
				JsonFile.save.Controls.Inventory = key;
			break;
		case "Skip":
		case "skip":
				JsonFile.save.Controls.Skip = key;
			break;
		case "Minimap":
		case "minimap":
				JsonFile.save.Controls.Minimap = key;
			break;
		}
		SaveData.queueSave = true;
	}
	public static string GetKey(string name){
		string key = "f12";
		switch (name) {
		case "Left":
		case "left":
			key = JsonFile.save.Controls.Left;
			break;
		case "Right":
		case "right":
			key = JsonFile.save.Controls.Right;
			break;
		case "Up":
		case "up":
			key = JsonFile.save.Controls.Up;
			break;
		case "Down":
		case "down":
			key = JsonFile.save.Controls.Down;
			break;
		case "Interact":
		case "interact":
			key = JsonFile.save.Controls.Interact;
			break;
		case "Inventory":
		case "inventory":
			key = JsonFile.save.Controls.Inventory;
			break;
		case "Skip":
		case "skip":
			key = JsonFile.save.Controls.Skip;
			break;
		case "Minimap":
		case "minimap":
			key = JsonFile.save.Controls.Minimap;
			break;
		}
		if (key == null || key.Equals ("") || key.Equals(" ")) {
			key = "f12";
		}
		return key;
	}

}
