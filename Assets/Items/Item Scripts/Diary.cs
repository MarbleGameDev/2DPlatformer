using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Diary : Iitem {
	public void Use(){
		Debug.Log("I feel used");
		InventoryData.RemoveItem (this, 1);
	}
	public void Drop(){
		InventoryData.RemoveItem (this, 1);
	}
    public string ToString() {
        return "Diary";
    }
}
