using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(OpenWindow))]
public class DialogueObject : MonoBehaviour, IDialogue {
	public string Name;
	private string[] dialogue = new string[20];
	public string prompt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public string GetName(){
		return Name;
	}
	public void OpenDialogue(){
		if (gameObject.transform.childCount > 1) { 	//Branching Dialogue
			Debug.Log("Branching Dialogue!!!!");
			var dialogues = new List<IDialogue> ();
			foreach (Transform child in gameObject.transform){
				if (child.GetComponent<IDialogue>() != null)
					dialogues.Add(child.GetComponent<IDialogue>());
			}
			int i = 0;
			foreach (IDialogue dial in dialogues){
				dialogue[i] = dial.GetName();
				i++;
			}
			GetComponent<OpenWindow>().Open();
			OptionButtons opBtn = GameObject.Find("BranchingDialogue(Clone)").GetComponentInChildren<OptionButtons>();
			opBtn.prompt = prompt;
			opBtn.optionNames = dialogue;
			opBtn.nextDialogue = dialogues;
			opBtn.Click();
		}else{ 	//Linear Dialogue
			Debug.Log("Linear Dialogue!!");
			GetComponent<OpenWindow>().Open();


		}

	}
}
