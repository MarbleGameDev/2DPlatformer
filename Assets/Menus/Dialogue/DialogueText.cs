using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour {
	int paragraphNum = 0;
	[HideInInspector]
	public string[] paragraphs;
	Text txt;
	MenuManager menu;
	// Use this for initialization
	void Awake () {
		menu = GameObject.Find ("Main Canvas").GetComponent<MenuManager> ();
		txt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (InputManager.GetKey("Skip"))) {
			Click();
		}
	}

	public void Click(){
		if (paragraphNum < paragraphs.Length) {
			if (txt != null){
			txt.text = paragraphs [paragraphNum];
			paragraphNum++;
			}
		} else {
			menu.CloseWindow();
		}
	}

	public void SetupParagraphs(string[] par){
		this.paragraphs = par;
	}
}
