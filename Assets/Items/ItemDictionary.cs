using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemDictionary : MonoBehaviour{

	public static Dictionary<string, Func<Iitem>> itemList = new Dictionary<string, Func<Iitem>>();

	/*
	public static void AddItem(string name, Func<Iitem> functclass){ 	//Not needed since the RegisterItems class used the dictionary directly
		itemList.Add (name, functclass);
	}
	*/

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
}
