using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryDictionary : MonoBehaviour {

    private Dictionary<object, int> itemList = new Dictionary<object, int>();
    private List<string> weaponList = new List<string>();
    private List<string> equipList = new List<string>();
    public void Add<T>(T obj, int amount) where T : class {
        itemList.Add(obj, amount);
    }
    public T GetValue<T>(string key) where T : class {
        if (itemList.ContainsKey(key))
            return itemList[key] as T;
        return null;
    }
    public bool Contains(string key) {
        return itemList.ContainsKey(key);
    }

    public bool IsWeapon(string key) {
        return weaponList.Contains(key);
    }
    public bool IsEquippable(string key) {
        return equipList.Contains(key);
    }
}
