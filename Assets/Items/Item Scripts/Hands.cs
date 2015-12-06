using UnityEngine;
using System.Collections;

public class Hands : Iitem {
	public void Use(){
		Equip ();
	}
	public void Drop(){

	}
	public void Equip(){
		InventoryData.EquippedItem = "Hands";
		InventoryData.UpdateInv ();
	}
	public float Attack(){
		return 0.5f;
	}
}
