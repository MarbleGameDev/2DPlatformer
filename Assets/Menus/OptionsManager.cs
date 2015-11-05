using UnityEngine;
using System.Collections;

public class OptionsManager : MonoBehaviour {
	public Transform window;
	static Transform newWindow;
	static string currentWindowName = null;

	public Transform video;
	public Transform audio;
	public Transform gameplay;
	public Transform advanced;
	
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
		case "VideoSettings":
			newWindow = Instantiate(video);
			newWindow.SetParent(window, false);
			break;
		case "AudioSettings":
			newWindow = Instantiate(audio);
			newWindow.SetParent(window, false);
			break;
		case "GameplaySettings":
			newWindow = Instantiate(gameplay);
			newWindow.SetParent(window, false);
			break;
		case "AdvancedSettings":
			newWindow = Instantiate(advanced);
			newWindow.SetParent(window, false);
			break;
		}
	}
	public void CloseWindow(){
		windowOpen = false;
		if (currentWindowName != null) {
			Destroy (GameObject.Find (currentWindowName + "(Clone)"));
		}
	}
}
