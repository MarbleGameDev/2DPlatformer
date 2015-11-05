using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsBack : MonoBehaviour {
	MenuManager menu;
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(() => { click(); });
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void click (){
		menu.CloseWindow ();
		if (Application.loadedLevelName.Equals ("MainMenu")) {
			menu.OpenWindow ("MainMenu");
		} else {
			menu.OpenWindow ("PauseMenu");
		}
	}
}
