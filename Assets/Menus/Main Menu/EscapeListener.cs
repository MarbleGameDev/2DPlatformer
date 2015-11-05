using UnityEngine;
using System.Collections;

public class EscapeListener : MonoBehaviour {
	public string menuName;
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
	}

	void click (){
		menu.CloseWindow ();
		if (menuName != menu.GetCurrentWindow ()) {
			menu.OpenWindow (menuName);
		} else {
			menu.OpenWindow ("");
		}
	}
}
