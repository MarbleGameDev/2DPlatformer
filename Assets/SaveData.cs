﻿using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {
	public delegate void resetData();
	public static event resetData ResetInv;
	public delegate void resetQuestData();
	public static event resetQuestData ResetQuests;

	public static int gameHours, gameDays;
	public static double gameMinutes;
	
	public static string EquippedItem = "Hands";

	public static string currentQuest = "";

	public static string[] genericChestNames;
	public static bool[] genericChestValues;
	// Use this for initialization
	void Awake () {
		genericChestValues = new bool[1000];
		genericChestNames = new string[1000];
		GetData ();
	}

	public static void ResetInvData(){
		if (ResetInv != null) {
			ResetInv ();
		}
		StoreData ();
	}
	public static void ResetQuestData(){
		if (ResetQuests != null) {
			ResetQuests ();
		}
		StoreData ();
	}

	void Start(){
		InvokeRepeating ("Store", 1f, (float)(Settings.saveInterval * 60));
	}

	void Store(){
		StoreData ();
	}

	public static void StoreData(){
		PlayerPrefs.SetInt ("gameDays", gameDays);
		PlayerPrefs.SetInt ("gameHours", gameHours);
		PlayerPrefs.SetFloat ("gameMinutes", (float)gameMinutes);
		PlayerPrefs.SetString ("equippedItem", EquippedItem);
		PlayerPrefs.SetString ("currentQuest", currentQuest);
		PlayerPrefs.Save ();
	}

	public static void GetData(){
		gameHours = PlayerPrefs.GetInt ("gameHours");
		gameDays = PlayerPrefs.GetInt ("gameDays");
		gameMinutes = (double)PlayerPrefs.GetFloat ("gameMinutes");
		EquippedItem = PlayerPrefs.GetString ("equippedItem");
		currentQuest = PlayerPrefs.GetString ("currentQuest");
	}
	
	void AddQuestResets(){
		ResetQuests += SampleQuest.Reset;
	}
}
