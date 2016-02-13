using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Remoting;

public class InterfaceDictionary{
	private Dictionary<string, object> itemList = new Dictionary<string, object>();
	public void Add<T>(string key, T obj) where T : class{
		itemList.Add (key, obj);
	}
    public bool Contains(string key) {
        return itemList.ContainsKey(key);
    }
    /*
	public T GetValue<T>(string key) where T : class{
		if (itemList.ContainsKey(key))
			return itemList [key] as T;
		return null;
	}
	public bool IsWeapon(string key){
		return weaponList.Contains (key);
	}
	public bool IsEquippable(string key){
		return equipList.Contains (key);
	}
    */
	/// <summary>
	/// Returns Item object from given name
	/// </summary>

    public object GetItem(string name) {
        if (itemList.ContainsKey(name)) {
            ObjectHandle hand = Activator.CreateInstance(null, name);
            var obj = hand.Unwrap();
            return obj;
        }
        return null;
    }
}
