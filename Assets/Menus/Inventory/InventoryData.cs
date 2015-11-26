﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class InventoryData : MonoBehaviour {

	public static Dictionary<string, int> inventory = new Dictionary<string, int> ();

	public delegate void InvChanged();
	public static event InvChanged OnChange;
	// Use this for initialization
	void Start () {

	}
	void Awake (){

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	public bool HasItem(string item){
		return inventory.ContainsKey (item);
	}

	public void AddItem (string name, int number){
		if (!HasItem (name)) {
			inventory.Add (name, number);
		} else {
			inventory[name] += number;
		}
		if (OnChange != null)
			OnChange ();
	}

	public bool RemoveItem (string name, int number){
		if (HasItem (name) && inventory [name] - number >= 0) {
			inventory [name] -= number;
			if (OnChange != null)
				OnChange ();
			return true;
		} else {
			return false;
		}
	}

}
