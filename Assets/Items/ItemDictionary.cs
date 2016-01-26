using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemDictionary : MonoBehaviour{
	
	public static InterfaceDictionary itemDict = new InterfaceDictionary ();
	
	public static void UseItem(string name){
		if (itemDict.Contains(name)) {
			Iitem itm = itemDict.GetValue<Iitem>(name);
			itm.Use();
		}
	}
	
	public static void EquipItem(string name){
		if (itemDict.Contains(name) && (itemDict.IsWeapon(name) || itemDict.IsEquippable(name))) {
			IEquippable itm = itemDict.GetValue<IEquippable>(name);
			itm.Equip();
		}
	}
	
	public static void DropItem(string name){
		if (itemDict.Contains(name)) {
			Iitem itm = itemDict.GetValue<Iitem>(name);
			itm.Drop();
		}
	}
	
	public static float AttackItem(string name){
		if (itemDict.Contains (name) && itemDict.IsWeapon (name)) {
			IWeapon itm = itemDict.GetValue<IWeapon> (name);
			return itm.Attack ();
		} else {
			return 0f;
		}
	}
    public static float CooldownItem(string name) {
        if (itemDict.Contains(name) && itemDict.IsWeapon(name)) {
            IWeapon itm = itemDict.GetValue<IWeapon>(name);
            return itm.swingSpeed;
        } else {
            return 0f;
        }
    }
    public static float RangeItem(string name) {
        if (itemDict.Contains(name) && itemDict.IsWeapon(name)) {
            IWeapon itm = itemDict.GetValue<IWeapon>(name);
            return itm.range;
        } else {
            return 0f;
        }
    }
}
