using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public Transform window;
	static Transform newWindow;
	static string currentWindowName;
	public Transform mainMenu;
	public Transform optionsMenu;
	public static bool windowOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OpenWindow(string name){
		windowOpen = true;
		currentWindowName = name;
		switch (name) {
		case "mainMenu":
			newWindow = Instantiate(mainMenu);
			newWindow.SetParent(window, false);
			break;
		case "optionsMenu":
			newWindow = Instantiate(optionsMenu);
			newWindow.SetParent(window, false);
			break;
		}
	}
	public void CloseWindow(){
		windowOpen = false;
		Destroy(GameObject.Find (currentWindowName + "(Clone)"));
	}
}