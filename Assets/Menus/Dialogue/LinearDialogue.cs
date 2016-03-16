using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class LinearDialogue : MonoBehaviour {
    int dialogueNum = 0;
    public string[] dialogue;
    public UnityEvent endFunct;
    public IDialogue nextDialogue;
    Text txt;
	bool toDisplay = false;
    MenuManager menu;
	string setText = "";
    void Awake() {
        menu = GameObject.Find("Main Canvas").GetComponent<MenuManager>();
        txt = GetComponent<Text>();
		InvokeRepeating("DisplayText", .15f, Settings.textTypeSpeed);
		
    }

	void DisplayText() {
		if (toDisplay) {
			if (txt != null) {
				if (txt.text.Length < setText.Length) {
					txt.text += setText.Substring(txt.text.Length, 1);
				} else {
					toDisplay = false;
				}
			}
		}
	}

    void Update()
    {
        if (Input.GetKeyDown(InputManager.GetKey("Skip")))
        {
            Click();
        }
    }

    public void Click() {
        if (dialogueNum < dialogue.Length)
        {
            if (txt != null)
            {
				txt.text = "";
				setText = dialogue[dialogueNum].Replace("[player]", JsonFile.save.PlayerData.playerName);
                dialogueNum++;
				toDisplay = true;
            }
        }
        else {
			CancelInvoke("DisplayText");
            menu.CloseWindow();
            if (endFunct != null)
            {
                endFunct.Invoke();
            }
            if (nextDialogue != null)
                nextDialogue.OpenDialogue();
        }
    }
}
