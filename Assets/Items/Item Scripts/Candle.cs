using UnityEngine;
using System.Collections;

public class Candle : IEquippable {
	public void Use(){
		Equip ();
	}
	public void Drop(){

	}
	public void Equip(){
		InventoryData.EquippedItem = "Candle";
		InventoryData.UpdateInv ();
	}
}
