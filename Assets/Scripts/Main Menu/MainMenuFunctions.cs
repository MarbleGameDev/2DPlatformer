using UnityEngine;
using System.Collections;

public class MainMenuFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickEvent(){
		Application.LoadLevel (1);
	}

	public void optionsClick(){
		Application.LoadLevel ("Options Menu");
	}
}
