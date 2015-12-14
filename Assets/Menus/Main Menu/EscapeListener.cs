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
		if (Input.GetKeyDown (InputManager.GetKey("Inventory"))) {
			inventory();
		}
		if (Input.GetButtonDown ("Escape")) {
			click();
		}
	}

	void click (){
		if (MenuManager.windowOpen) {
			menu.CloseWindow ();
		}else {
			menu.OpenWindow (menuName);
		}
	}

	void inventory (){
		if (MenuManager.windowOpen) {
			menu.CloseWindow ();
		}else {
			menu.OpenWindow (inventoryName);
		}
	}

}
