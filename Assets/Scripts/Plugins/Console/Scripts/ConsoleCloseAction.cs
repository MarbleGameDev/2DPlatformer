using UnityEngine;
using System.Collections;

public class ConsoleCloseAction : ConsoleAction {
    public GameObject ConsoleGui;
	ConsoleToggler tog;
	void Start () {
		tog = GameObject.Find("Console").GetComponentInChildren<ConsoleToggler>();
	}
    public override void Activate() {
#if UNITY_3_5
        ConsoleGui.active = false;
#else
        ConsoleGui.SetActive(false);
		tog.consoleEnabled = false;
#endif
    }
}
