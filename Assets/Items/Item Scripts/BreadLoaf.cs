using UnityEngine;
using System.Collections;

[System.Serializable]
public class BreadLoaf : IFood {
	string description = "Makes you not hungry";
	float health = 1;
	int cost = 0;
	public int Cost {
		get {
			return cost;
		}
		set {
			cost = value;
		}
	}

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
		return "Loaf of Bread";
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
