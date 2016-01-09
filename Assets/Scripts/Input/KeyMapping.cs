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

	void Update () { 	//Really need to work on figuring out a better solution
		if (isSelected) {
			if (Input.anyKeyDown) {
				string inputString = "";
				if (Input.inputString.Equals(" ")){
				    inputString = "space";
				}else if (Input.inputString.Equals("\t")){
					inputString = "tab";
				}else if (Input.inputString.Equals("\n") || Input.inputString.Equals("\r")){
					inputString = ".";
				}else if (Input.inputString.Equals("\b")){
					inputString = "backspace";
				}else if (Input.GetKey("tab")){
					inputString = "tab";
				}else if (Input.inputString.Equals("")){
					inputString = "left shift";
				}else{
					inputString = Input.inputString;
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
