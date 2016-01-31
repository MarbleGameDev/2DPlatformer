using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Candle : IEquippable {
	public void Use(){
		Equip ();
	}
	public void Drop(){

	}
	public void Equip(){
        InventoryData.equipItem(this);
		InventoryData.UpdateInv ();
	}
    public override string ToString() {
        return "Candle";
    }
}
