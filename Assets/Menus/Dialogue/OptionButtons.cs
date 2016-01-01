using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionButtons : MonoBehaviour {
	public Button optionButton = null;
	public string prompt = null;
	public string[] optionNames = null;
	public List<IDialogue> nextDialogue = new List<IDialogue> ();

	public void Click(){
        GetComponent<Text>().text = prompt;
		int i = 0;
		foreach (IDialogue dials in nextDialogue) {
			Button btn = Instantiate(optionButton);
			btn.transform.SetParent(this.gameObject.transform, false);
			btn.GetComponentInChildren<Text>().text = optionNames[i];
			btn.transform.name = optionNames[i];
			btn.GetComponent<OptionButtonClick>().nextDialogue = nextDialogue[i];
			i++;
		}
	}
}
