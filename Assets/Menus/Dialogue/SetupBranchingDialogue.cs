using UnityEngine;
using System.Collections;
using UnityEngine.Events;

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
	public ICheckData data = null;
	public string[] defaultDialogue;
	public UnityEvent defaultEndingFunction;
	// Use this for initialization
	void Start () {
		if (GetComponent<ICheckData> () != null) {
			data = GetComponent<ICheckData>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDialogue(){
		
	}
}
