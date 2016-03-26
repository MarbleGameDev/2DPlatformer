using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Hands : IWeapon {
    string ide = GUID.GetUniqueID();
    string[] information = new string[4];
    string name = "Hands", description = "Nothing but skin.";
    float swordDamage = 0f, swordSwingSpeed = 1f, swordRange = 1f;
    public float damage {
        get {
            return swordDamage;
        }
        set {
            swordDamage = value;
        }
    }
    public float swingSpeed {    //10 per second
        get {
            return swordSwingSpeed;
        }
        set {
            swordSwingSpeed = value;
        }
    }
    public float range {
        get {
            return swordRange;
        }
        set {
            swordRange = value;
        }
    }
    public string ID {
        get {
            return ide;
        }
        set {
            ide = value;
        }
    }
    public string Name {
        get {
            return name;
        }
        set {
            name = value;
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
	int cost = 0;
	public int Cost {
		get {
			return cost;
		}
		set {
			cost = value;
		}
	}

	public void Use(){
		Equip ();
	}
	public void Drop(){

	}
	public void Equip(){
        InventoryData.equippedItem = -1;
		InventoryData.UpdateInv ();
	}
	public float Attack(){
		return damage;
	}
    public string toString() {
        return name;
    }
    public string[] DisplayInformation() {
        information[0] = this.description;
        information[1] = damage.ToString();
        information[2] = swingSpeed.ToString();
        information[3] = range.ToString();
        return information;
    }
}
