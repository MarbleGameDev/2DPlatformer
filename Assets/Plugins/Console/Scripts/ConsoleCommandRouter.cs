using UnityEngine;
using System.Collections;

public class ConsoleCommandRouter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var repo = ConsoleCommandsRepository.Instance;
		repo.RegisterCommand("help", Help);
		repo.RegisterCommand("load", Load);
		repo.RegisterCommand ("exit", Exit);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string Exit(params string[] args){
		Application.Quit ();
		return "Closing Game";
	}

	public string Help(params string[] args){
		var repo = ConsoleCommandsRepository.Instance;
		repo.getDictionary ();
		return "";
	}

	public string Load(params string[] args) {
		var fileName = args[0];
		Application.LoadLevel(fileName);
		return "Loaded " + fileName;
	}
}
