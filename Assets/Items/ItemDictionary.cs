using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemDictionary : MonoBehaviour{

	public static Dictionary<string, Func<Iitem>> itemList = new Dictionary<string, Func<Iitem>>();

	public static void UseItem(string name){
		if (itemList.ContainsKey (name)) {
			(itemList [name])().Use();
		}
	}

	public static void EquipItem(string name){
		if (itemList.ContainsKey (name)) {
			(itemList [name])().Equip();
		}
	}

	public static void DropItem(string name){
		if (itemList.ContainsKey (name)) {
			(itemList [name])().Drop();
		}
	}

	public static float AttackItem(string name){
		if (itemList.ContainsKey (name)) {
			return (itemList [name]) ().Attack ();
		} else {
			return 0f;
		}
	}
}
