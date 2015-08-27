using UnityEngine;
using System.Collections;
using System;

public class ConsoleCommandRouter : MonoBehaviour {
	DevOptions dev;
	GameObject console;
	// Use this for initialization
	void Start () {
		console = GameObject.Find ("character");
		dev = console.GetComponent<DevOptions>();
		var repo = ConsoleCommandsRepository.Instance;
		repo.RegisterCommand ("exit", Exit);
		repo.RegisterCommand ("fly", Fly);
		repo.RegisterCommand("help", Help);
		repo.RegisterCommand("load", Load);
		repo.RegisterCommand ("noclip", noClip);
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
		String fileName;
		try{
			fileName = args[0];
		} catch (Exception e){
			return "Missing Level Name";
		}
		Application.LoadLevel(fileName);
		return "Loaded " + fileName;
	}

	public string noClip(params string[] args){
		String fileName;
		try{
			fileName = args[0];
		} catch (Exception e){
			return "Missing <true/false>";
		}
		if (fileName.Equals ("true")) {
			dev.noclip = true;
		}
		if (fileName.Equals ("false")) {
			dev.noclip = false;
		}
		return "Noclip Set to: " + fileName;
	}

	public string Fly(params string[] args){
		String fileName;
		try{
			fileName = args[0];
		} catch (Exception e){
			return "Missing <true/false>";
		}
		if (fileName.Equals ("true")) {
			dev.fly = true;
		}
		if (fileName.Equals ("false")) {
			dev.fly = false;
		}
		return "Fly Set to: " + fileName;
	}
}
