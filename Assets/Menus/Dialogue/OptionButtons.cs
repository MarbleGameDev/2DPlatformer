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
		int i = 0;
		foreach (IDialogue dials in nextDialogue) {
			Debug.Log("1");
			Button btn = Instantiate(optionButton);
			btn.transform.SetParent(transform, false);
			btn.GetComponentInChildren<Text>().text = optionNames[i];
			btn.transform.name = optionNames[i];
			btn.GetComponent<OptionButtonClick>().nextDialogue = nextDialogue[i];
			i++;
		}
	}
}
