using UnityEngine;
using System.Collections;

[RequireComponent (typeof(OpenWindow))]
public class SetupBranchingDialogue : MonoBehaviour {
	[System.Serializable]
	public class DialoguePaths{
		public bool isChoice;
		public string[] option;
		public int[] destination;
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
