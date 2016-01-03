using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent (typeof(OpenWindow))]
public class SetupDialogue : MonoBehaviour {
	[System.Serializable]
	public class DialoguePaths{
		public string[] speech;
		public UnityEvent endingFunction;
	}

	[Space(10)]

	[Header("Dialogues:")]
	public DialoguePaths[] dialogues;
	[Header("Dialogue Tree Decisions:")]
	[Space(15)]

	public ICheckData data = null;
	public string[] defaultDialogue;
	public UnityEvent defaultEndingFunction;

	void Start () {
		if (GetComponent<ICheckData> () != null) {
			data = GetComponent<ICheckData>();
		}
	}

	public void OpenDialogue(){
		if (GetComponent<OpenWindow> () != null) {
			DialogueText dtxt = GameObject.Find ("Paragraph Text").GetComponent<DialogueText> ();
			if (data != null){
				bool set = false;
				for (int i = 0; i < dialogues.Length; i++){
					if (data.CheckData(i)){
						dtxt.paragraphs = dialogues[i].speech;
						dtxt.endFunct = dialogues[i].endingFunction;
						set = true;
					}
				}
				if (set == false){
					dtxt.paragraphs = defaultDialogue;
					dtxt.endFunct = defaultEndingFunction;
				}
			}
			dtxt.Click ();
		}
	}
}