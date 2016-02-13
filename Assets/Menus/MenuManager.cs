using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public Transform window;
	static Transform newWindow;
	public static string currentWindowName = "";

	public Transform mainMenu;
	public Transform optionsMenu;
	public Transform newGame;
	public Transform pauseMenu;
	public Transform inventory;

	public static bool windowOpen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (windowOpen && !currentWindowName.Contains("LinearDialogue")) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		
	}
	public void OpenWindow(string name){
		windowOpen = true;
		currentWindowName = name;
		switch (name) {
		case "MainMenu":
			newWindow = Instantiate(mainMenu);
			newWindow.SetParent(window, false);
			break;
		case "OptionsMenu":
			newWindow = Instantiate(optionsMenu);
			newWindow.SetParent(window, false);
			break;
		case "newGame":
			newWindow = Instantiate(newGame);
			newWindow.SetParent(window, false);
			break;
		case "PauseMenu":
			newWindow = Instantiate(pauseMenu);
			newWindow.SetParent(window, false);
			break;
		case "Inventory":
			newWindow = Instantiate (inventory);
			newWindow.SetParent(window, false);
			break;
		}
	}
	public void OpenCustomWindow(Transform tempWindow){
		windowOpen = true;
		currentWindowName = tempWindow.name;
		newWindow = Instantiate(tempWindow);
		newWindow.SetParent(window, false);
	}
	public void CloseWindow(){
		windowOpen = false;
		if (currentWindowName != null && !currentWindowName.Equals("")) {
			DestroyImmediate (GameObject.Find (currentWindowName + "(Clone)"));
		}
	}
	public string GetCurrentWindow(){
		return currentWindowName;
	}

	public bool IsWindowOpen(){
		return windowOpen;
	}
}