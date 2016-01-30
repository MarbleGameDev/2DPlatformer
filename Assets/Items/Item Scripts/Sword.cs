using UnityEngine;
using System.Collections;

public class Sword : IWeapon {
	public float damage{
		get{
			return PlayerPrefs.GetFloat("SwordDamage", 3f);
		}
		set{
			PlayerPrefs.SetFloat("SwordDamage", value);
		}
	}
	public float swingSpeed{    //10 per second
		get{
			return PlayerPrefs.GetFloat("SwordSpeed", 10f);
		}
		set{
			PlayerPrefs.SetFloat("SwordSpeed", value);
			PlayerPrefs.Save();
		}
	}
	public float range{
		get{
			return PlayerPrefs.GetFloat("SwordRange", 1.5f);
		}
		set{
			PlayerPrefs.SetFloat("SwordRange", value);
		}
	}
    
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
		return damage;
	}
}
