﻿using UnityEngine;
using System.Collections;

public class EscapeListener : MonoBehaviour {
	public string menuName;
	public string inventoryName = "Inventory";
	MenuManager menu;
	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Inventory")) {
			Debug.Log ("Inventory");
			inventory();
		}
		if (Input.GetButtonDown ("Escape")) {
			Debug.Log ("Escape");
			click();
		}
	}

	void click (){
		if (menu.IsWindowOpen ()) {
			menu.CloseWindow ();
		}else {
			menu.OpenWindow (menuName);
		}
	}

	void inventory (){
		if (menu.IsWindowOpen ()) {
			menu.CloseWindow ();
		}else {
			menu.OpenWindow (inventoryName);
		}
	}

}
