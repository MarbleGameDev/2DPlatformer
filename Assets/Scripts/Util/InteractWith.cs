﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class InteractWith : MonoBehaviour {

	public UnityEvent onInteract;
	public UnityEvent onEnter;
	public UnityEvent onExit;

	string keyListener = "Interact";

	public bool inArea = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string key = InputManager.GetKey (keyListener);
		if (Input.GetKeyDown (key) && inArea && (!MenuManager.windowOpen || GetComponent<Inventory>() != null)) { 	//GenericChest uses the interactwith to retrieve items
			//Debug.Log ("Interacts!");
			onInteract.Invoke ();
		}
	}

	void OnTriggerEnter(Collider other){
		inArea = true;
		onEnter.Invoke ();
	}

	void OnTriggerExit(Collider other){
		inArea = false;
		onExit.Invoke ();
	}
}
