﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class FrogLegs : IFood {
	string description = "Eww.";
	float health = 1;
	public string Description {
		get {
			return description;
		}
		set {
			description = value;
		}
	}
	int cost = 0;
	public int Cost {
		get {
			return cost;
		}
		set {
			cost = value;
		}
	}

	public void Use() {
		Equip();
	}
	public void Drop() {

	}
	public void Equip() {
		InventoryData.equipItem(this);
		InventoryData.UpdateInv();
	}
	public override string ToString() {
		return "Frog Legs";
	}
	public string[] DisplayInformation() {
		string[] description = new string[1];
		description[0] = this.description;
		return description;
	}
	public void Eat() {
		GameObject.Find("Character").GetComponent<Health>().Damage(-health);
	}
}
