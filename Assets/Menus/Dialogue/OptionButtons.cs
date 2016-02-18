using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class OptionButtons : MonoBehaviour {
	public Button optionButton = null;
	public Transform promptObj = null;
	public string prompt = null;
	public string[] optionNames = null;
	public List<IDialogue> nextDialogue = new List<IDialogue> ();

	public void Click(){
		Transform prmt = Instantiate(promptObj);
		prmt.transform.SetParent(this.gameObject.transform, false);
		prmt.GetComponent<Text>().text = prompt + "\n";
		int i = 0;
		foreach (string str in optionNames) {
			Button btn = Instantiate(optionButton);
			btn.transform.SetParent(this.gameObject.transform, false);
			btn.GetComponentInChildren<Text>().text = str;
			btn.transform.name = str;
			btn.GetComponent<OptionButtonClick>().nextDialogue = nextDialogue[i];
			i++;
		}
	}
}
