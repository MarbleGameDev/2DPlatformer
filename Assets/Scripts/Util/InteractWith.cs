using UnityEngine;
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
		if (Input.GetButtonDown(keyListener) && inArea) {
			Debug.Log ("Interacts!");
			onInteract.Invoke ();
		}
		inArea = false;
	}

	void OnTriggerStay2D(Collider2D other){
		inArea = true;
		onEnter.Invoke ();
	}

	void OnTriggerExit2D(Collider2D other){
		inArea = false;
		onExit.Invoke ();
	}
}
