using UnityEngine;
using System.Collections;

public class Planks : Iitem {
	string description = "One wooden wood.";

	public string Description {
		get {
			return description;
		}
		set {
			description = value;
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
		return "Plank";
	}
	public string[] DisplayInformation() {
		string[] description = new string[1];
		description[0] = this.description;
		return description;
	}
}
