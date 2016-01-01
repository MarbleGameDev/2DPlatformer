using UnityEngine;
using System.Collections;

public class OptionButtonClick : MonoBehaviour {
	public IDialogue nextDialogue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Click(){
		nextDialogue.OpenDialogue ();
	}
}
