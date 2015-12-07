using UnityEngine;
using System.Collections;

public class StartingMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("MainCanvas").GetComponent<MenuManager> ().OpenWindow("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
