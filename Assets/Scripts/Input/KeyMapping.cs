using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

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
				foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))){
					if (Input.GetKeyDown(kcode) && !kcode.ToString().Equals("LeftCommand")){
						string key = Regex.Replace(kcode.ToString(), "(\\B[A-Z])", " $1").ToLower();
						if (key.Equals("left control"))
							key = "left ctrl";
						InputManager.SetKey (keyName, key);
						isSelected = false;
						txt.text = key;
					}
				}
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
