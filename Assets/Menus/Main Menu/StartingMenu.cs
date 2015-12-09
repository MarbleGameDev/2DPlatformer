using UnityEngine;
using System.Collections;

public class StartingMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MenuManager menu = GetComponent<MenuManager> ();
		menu.OpenWindow("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
