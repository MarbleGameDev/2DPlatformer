using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {
	MenuManager man;
	// Use this for initialization
	void Start () {
		man = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Load(string level){
		man.CloseWindow ();
		Application.LoadLevel (level);
	}
}
