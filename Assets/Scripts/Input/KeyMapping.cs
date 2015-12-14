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
				InputManager.SetKey (keyName, Input.inputString);
				isSelected = false;
				txt.text = Input.inputString;
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
