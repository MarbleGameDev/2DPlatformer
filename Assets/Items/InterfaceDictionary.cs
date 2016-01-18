using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InterfaceDictionary{
	private Dictionary<string, object> itemList = new Dictionary<string, object>();
	private List<string> weaponList = new List<string>();
	private List<string> equipList = new List<string> ();
	public void Add<T>(string key, T obj) where T : class{
		itemList.Add (key, obj);
		if (obj is IWeapon)
			weaponList.Add (key);
		if (obj is IEquippable)
			equipList.Add (key);
	}
	public T GetValue<T>(string key) where T : class{
		if (itemList.ContainsKey(key))
			return itemList [key] as T;
		return null;
	}
	public bool Contains(string key){
		return itemList.ContainsKey (key);
	}

	public bool IsWeapon(string key){
		return weaponList.Contains (key);
	}
	public bool IsEquippable(string key){
		return equipList.Contains (key);
	}
}
