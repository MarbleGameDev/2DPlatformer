using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent (typeof(OpenWindow))]
public class DialogueObject : MonoBehaviour, IDialogue {
    [Tooltip("Must be unique among similar children")]
	public string Name;
    [Header("Leave Empty for Options")]
    public string[] dialogue;
    [Header("Not used with Dialogue ")]
	public string prompt;
    [Header("Not used with Options")]
    public UnityEvent endFunct;

    public Transform[] extraChildren;
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
		if (gameObject.transform.childCount + extraChildren.Length > 1) { 	//Branching Dialogue
			var dialogues = new List<IDialogue> ();
			foreach (Transform child in gameObject.transform){
				if (child.GetComponent<IDialogue>() != null)
					dialogues.Add(child.GetComponent<IDialogue>());
			}
            foreach (Transform child in extraChildren) {
                if (child.GetComponent<IDialogue>() != null)
                    dialogues.Add(child.GetComponent<IDialogue>());
            }
            int i = 0;
            dialogue = new string[dialogues.Count];
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
            GetComponent<OpenWindow>().Open();
            LinearDialogue lnDial = GameObject.Find("LinearDialogue(Clone)").GetComponentInChildren<LinearDialogue>();
            lnDial.dialogue = dialogue;
            lnDial.endFunct = endFunct;
            if (gameObject.transform.childCount > 0) {
                lnDial.nextDialogue = gameObject.transform.GetChild(0).GetComponent<IDialogue>();
            } else if (extraChildren[0] != null) {
                lnDial.nextDialogue = extraChildren[0].GetComponent<IDialogue>();
            } else {
                lnDial.nextDialogue = null;
            }
            lnDial.Click();
        }

	}
}
