using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {
	public static bool stringUse;
	public static int levelNum = 1;
	public static string levelName;

    public void LoadScene(int num) {
        Application.LoadLevelAsync(num);
    }

	public void LoadLevel(int num){
		GameObject character = GameObject.Find("Character");
		character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -20 * num - .001f);
	}
	
	void Start () {
		if (Application.loadedLevel == 0) { 	//Not used to reduce loading times
			if (stringUse) {
				Application.LoadLevel (levelName);
			} else {
				Application.LoadLevel (levelNum);
			}
		}
	}

	private void Load(){
		//Debug.Log("Ima moving this");
		MenuManager menu = GameObject.Find("Main Canvas").GetComponent<MenuManager> ();
		menu.CloseWindow ();
		//Application.LoadLevelAsync (0);
		if (stringUse) {
			Application.LoadLevel (levelName);
		} else {
			Application.LoadLevel (levelNum);
		}
	}
}
