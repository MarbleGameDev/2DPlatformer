using UnityEngine;
using System.Collections;

public class ConsoleCloseAction : ConsoleAction {
    public GameObject ConsoleGui;
	void Start () {
		
	}
    public override void Activate() {
#if UNITY_3_5
        ConsoleGui.active = false;
#else
        ConsoleGui.SetActive(false);
        MenuManager.windowOpen = false;
        ConsoleToggler.consoleEnabled = false;
        Input.ResetInputAxes();
#endif
    }
}
