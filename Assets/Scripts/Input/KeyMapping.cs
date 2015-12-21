using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyMapping : MonoBehaviour {
	public string keyName;
	bool isSelected;
	Button but;
	Text txt;
	// Use this for initialization
	void Start () {
		but = GetComponent<Button> ();
		txt = but.GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected) {
			if (Input.anyKeyDown) {
				string inputString = "";
				if (Input.inputString.Equals(" ")){
				    inputString = "space";
				}
				if (Input.inputString.Equals("\t")){
					inputString = "tab";
				}
				if (Input.inputString.Equals("\n") || Input.inputString.Equals("\r")){
					inputString = "enter";
				}
				if (Input.inputString.Equals("\b")){
					inputString = "backspace";
				}
				if (Input.GetKey("tab")){
					inputString = "tab";
				}
				InputManager.SetKey (keyName, inputString);
				isSelected = false;
				txt.text = inputString;
			}
		} else {
			txt.text = InputManager.GetKey (keyName);
		}
	}

	public void OnClick(){
		isSelected = true;
		txt.text = "|";
	}
}
