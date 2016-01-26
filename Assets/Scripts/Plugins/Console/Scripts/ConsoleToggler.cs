using UnityEngine;
using System.Collections;

public class ConsoleToggler : MonoBehaviour {
    public static bool consoleEnabled = false;
    public ConsoleAction ConsoleOpenAction;
    public ConsoleAction ConsoleCloseAction;

    void Update () {
        if (Input.GetButtonDown("Console")) {
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
        }
    }
}
