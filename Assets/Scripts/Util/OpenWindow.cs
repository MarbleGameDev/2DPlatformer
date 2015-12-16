using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour {
	public Transform window;
	MenuManager menu;
	// Use this for initialization
	void Start () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Open(){
		if (!MenuManager.windowOpen) {
			if (window != null){
				menu.OpenCustomWindow (window);
			}else{
				Debug.LogError("NullPointerException: No window object attached to the OpenWindow script");
			}
		}
	}
}
