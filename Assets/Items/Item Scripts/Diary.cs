using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Diary : Iitem {
    string description = "A collecion of notes.";

    public string Description {
        get {
            return description;
        }
        set {
            description = value;
        }
    }
    public void Use(){
		Debug.Log("I feel used");
		InventoryData.RemoveItem (this, 1);
	}
	public void Drop(){
		InventoryData.RemoveItem (this, 1);
	}
    public override string ToString() {
        return "Diary";
    }
    public string[] DisplayInformation() {
        string[] description = new string[1];
        description[0] = this.description;
        return description;
    }
}
