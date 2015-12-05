﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour {
	public Transform nItem;
	public Transform panel;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddNofication(string title, string content){
		Transform newNote = Instantiate (nItem);
		newNote.name = "Notification";
		newNote.SetParent (panel, false);
		Text newTitle = newNote.FindChild ("Title").GetComponent<Text> ();
		Text newContent = newNote.FindChild ("Content").GetComponent<Text> ();
		newTitle.text = title;
		newContent.text = content;

	}
}