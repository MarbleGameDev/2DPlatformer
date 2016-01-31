using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Hands : IWeapon {
	public float damage{
		get{
			return PlayerPrefs.GetFloat("HandDamage", 1f);
		}
		set{
			PlayerPrefs.SetFloat("HandDamage", value);
		}
	}
	public float swingSpeed{
		get{
			return PlayerPrefs.GetFloat("HandSpeed", 1f);
		}
		set{
			PlayerPrefs.SetFloat("HandSpeed", value);
			PlayerPrefs.Save();
		}
	}
	public float range{
		get{
			return PlayerPrefs.GetFloat("HandRange", 1f);
		}
		set{
			PlayerPrefs.SetFloat("HandRange", value);
		}
	}
    public string ID {
        get {
            return "hnd";
        }
        set {
            ID = value;
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
        return "Hands";
    }
}
