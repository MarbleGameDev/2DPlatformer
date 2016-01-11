using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {
	public static bool stringUse;
	public static int levelNum = 1;
	public static string levelName;

	public void LoadLevel(string name){
		stringUse = true;
		levelName = name;
		levelNum = 0;
		Load ();
	}

	public void LoadLevel(int num){
		stringUse = false;
		levelNum = num;
		levelName = "";
		Load ();
	}
	
	void Start () {
		if (Application.loadedLevel == 0) { 	//Not used to reduce loading times
			if (stringUse) {
				Application.LoadLevelAsync (levelName);
			} else {
				Application.LoadLevelAsync (levelNum);
			}
		}
	}

	private void Load(){
		//Debug.Log("Ima moving this");
		MenuManager menu = GameObject.Find("Main Canvas").GetComponent<MenuManager> ();
		menu.CloseWindow ();
		//Application.LoadLevelAsync (0);
		if (stringUse) {
			Application.LoadLevelAsync (levelName);
		} else {
			Application.LoadLevelAsync (levelNum);
		}
	}
}
