using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Candle : IEquippable {
    string description = "Light your way.";
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
    public string[] DisplayInformation() {
        string[] description = new string[1];
        description[0] = this.description;
        return description;
    }
}
