using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowChanger : MonoBehaviour {
	public string menuName;
	MenuManager menu;

	void Start () {
		GetComponent<Button>().onClick.AddListener(() => { click(); });
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
	}

	void Update () {

	}

	void click (){
		menu.CloseWindow ();
		menu.OpenWindow (menuName);
	}
}
