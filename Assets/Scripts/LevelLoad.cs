using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {
	public static bool stringUse;
	public static int levelNum = 1;
	public static string levelName;

	public void PrimeLevel(string name){
		stringUse = true;
		levelName = name;
		levelNum = 0;
	}

	public void PrimeLevel(int num){
		stringUse = false;
		levelNum = num;
		levelName = "";
	}
	
	void Start () {
		if (Application.loadedLevel == 0) {
			if (stringUse) {
				Application.LoadLevelAsync (levelName);
			} else {
				Application.LoadLevelAsync (levelNum);
			}
		}
	}

	public void Load(){
		MenuManager menu = GameObject.Find("Main Canvas").GetComponent<MenuManager> ();
		menu.CloseWindow ();
		if (stringUse) {
			Application.LoadLevelAsync (levelName);
		} else {
			Application.LoadLevelAsync (levelNum);
		}
	}
}
