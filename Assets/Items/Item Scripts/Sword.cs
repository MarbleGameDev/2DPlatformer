﻿using UnityEngine;
using System.Collections;

public class Sword : IWeapon {
	public void Use(){
		Equip ();
	}
	public void Drop(){

	}
	public void Equip(){
		InventoryData.EquippedItem = "Sword";
		InventoryData.UpdateInv ();
	}
	public float Attack(){
		return 1f;
	}
}
