using UnityEngine;
using System.Collections;

[RequireComponent (typeof(OpenWindow))]
public class SetupBranchingDialogue : MonoBehaviour {
	public int pathNum;
	public int choiceNum;
	[System.Serializable]
	public class DialoguePaths{
		public string[] speech;
	}

	public DialoguePaths[] dialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDialogue(){
		
	}
}
