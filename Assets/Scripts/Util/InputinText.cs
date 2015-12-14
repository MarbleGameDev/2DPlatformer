using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputinText : MonoBehaviour {
	Text txt;
	public string text; 	//In inspector, type out the normal phrase, putting "[key]" where the key should show up
	public string key;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
		txt.text = text.Replace ("[key]", InputManager.GetKey (key).ToUpper ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
