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
    MenuManager menu;
    void Awake() {
        menu = GameObject.Find("Main Canvas").GetComponent<MenuManager>();
        txt = GetComponent<Text>();
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
                txt.text = dialogue[dialogueNum].Replace("[player]", SaveData.playerName);
                dialogueNum++;
            }
        }
        else {
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
