using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupDialogue : MonoBehaviour {
	public string[] dialogueParagraphs;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDialogue(){
		DialogueText dtxt = GameObject.Find ("Paragraph Text").GetComponent<DialogueText> ();
		dtxt.SetupParagraphs (dialogueParagraphs);
		dtxt.Click ();
	}
}
