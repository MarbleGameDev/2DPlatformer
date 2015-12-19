using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent (typeof(OpenWindow))]
public class SetupDialogue : MonoBehaviour {
	[System.Serializable]
	public class DialoguePaths{
		public string[] speech;
	}

	[Space(10)]

	[Header("Dialogues:")]
	public DialoguePaths[] dialogues;
	[Header("Dialogue Tree Decisions:")]
	[Space(15)]

	public ICheckData data = null;
	public string[] defaultDialogue;

	[Tooltip ("Function that gets called once the dialogue is finished")]
	public UnityEvent endingFunction;

	void Start () {
		if (GetComponent<ICheckData> () != null) {
			data = GetComponent<ICheckData>();
		}
	}

	void Update () {
	
	}
	public void OpenDialogue(){
		if (GetComponent<OpenWindow> () != null) {
			DialogueText dtxt = GameObject.Find ("Paragraph Text").GetComponent<DialogueText> ();
			if (data != null){
				bool set = false;
				for (int i = 0; i < dialogues.Length; i++){
					if (data.CheckData(i)){
						dtxt.paragraphs = dialogues[i].speech;
						set = true;
					}
				}
				if (set == false){
					dtxt.paragraphs = defaultDialogue;
				}
			}
			dtxt.endFunct = endingFunction;
			dtxt.Click ();
		}
	}
}