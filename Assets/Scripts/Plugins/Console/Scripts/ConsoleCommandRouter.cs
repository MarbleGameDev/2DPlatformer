﻿using UnityEngine;
using System.Collections;
using System;
#pragma warning disable 0168
public class ConsoleCommandRouter : MonoBehaviour {
	GameObject console;
	NotificationManager noteman;
	// Use this for initialization
	void Start () {
		var repo = ConsoleCommandsRepository.Instance;
		noteman = GameObject.Find ("Notification Canvas").GetComponent<NotificationManager> ();

		repo.RegisterCommand ("debug", DebugOn);
		repo.RegisterCommand ("exit", Exit);
		repo.RegisterCommand("help", Help);
		repo.RegisterCommand("load", Load);
		repo.RegisterCommand ("noclip", noClip);
		repo.RegisterCommand ("notification", notification);
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
			Settings.noclip = true;
		}
		if (fileName.Equals ("false")) {
			Settings.noclip = false;
		}
		return "Noclip Set to: " + fileName;
	}
	

	public string DebugOn (params string[] args){
		String fileName;
		try{
			fileName = args[0];
		} catch (Exception e){
			return "Missing <true/false>";
		}
		if (fileName.Equals ("true")) {
			Settings.debug = true;
		}
		if (fileName.Equals ("false")) {
			Settings.debug = false;
		}
		return "Debug Set to: " + fileName;
	}

	public string notification (params string[] args){
		String title, content;
		try{
			title = args[0];
		} catch (Exception e){
			return "Missing title";
		}
		try{
			content = args[1];
		} catch (Exception e){
			return "Missing content";
		}
		noteman.AddNofication (title, content);
		return "notification created";
	}
}
