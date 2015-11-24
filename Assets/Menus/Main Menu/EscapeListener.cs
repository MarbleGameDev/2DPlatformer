using UnityEngine;
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
		if (Input.GetButtonDown ("Escape")) {
			click();
		}
		if (Input.GetButtonDown ("Inventory")) {
			inventory();
		}
	}

	void click (){
		Debug.Log ("Escape");
		if (menu.IsWindowOpen ()) {
			menu.CloseWindow ();
		}else {
			menu.OpenWindow (menuName);
		}
	}

	void inventory (){
		menu.OpenWindow (inventoryName);
	}
}
