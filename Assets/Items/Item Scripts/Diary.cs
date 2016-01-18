using UnityEngine;
using System.Collections;

public class Diary : Iitem {
	public void Use(){
		Debug.Log("I feel used");
		InventoryData.RemoveItem ("Diary", 1);
	}
	public void Drop(){
		InventoryData.RemoveItem ("Diary", 1);
	}
}
