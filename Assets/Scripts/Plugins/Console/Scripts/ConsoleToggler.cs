using UnityEngine;
using System.Collections;

public class ConsoleToggler : MonoBehaviour {
    public bool consoleEnabled = false;
    public ConsoleAction ConsoleOpenAction;
    public ConsoleAction ConsoleCloseAction;

    void Update () {
        if (Input.GetKeyDown(KeyCode.BackQuote)) {
            ToggleConsole();
        }
    }

    private void ToggleConsole() {
        consoleEnabled = !consoleEnabled;
        if (consoleEnabled) {
            ConsoleOpenAction.Activate();
        } else {
            ConsoleCloseAction.Activate();
			consoleEnabled = false;
			Debug.Log("off");
        }
    }
}
