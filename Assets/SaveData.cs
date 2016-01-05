using UnityEngine;
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

	public static string playerName = "Joshabar";

	public static string Left, Right, Up, Down, Interact, Inventory, Skip;
	// Use this for initialization
	void Awake () {
		GetData ();
		InventoryData.Awake ();
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
		PlayerPrefs.SetString ("Left", Left);
		PlayerPrefs.SetString ("Right", Right);
		PlayerPrefs.SetString ("Up", Up);
		PlayerPrefs.SetString ("Down", Down);
		PlayerPrefs.SetString ("Interact", Interact);
		PlayerPrefs.SetString ("Inventory", Inventory);
		PlayerPrefs.SetString ("Skip", Skip);
		PlayerPrefs.Save ();
	}

	public static void GetData(){
		gameHours = PlayerPrefs.GetInt ("gameHours");
		gameDays = PlayerPrefs.GetInt ("gameDays");
		gameMinutes = (double)PlayerPrefs.GetFloat ("gameMinutes");
		EquippedItem = PlayerPrefs.GetString ("equippedItem");
		currentQuest = PlayerPrefs.GetString ("currentQuest");
		Left = PlayerPrefs.GetString ("Left", "a");
		Right = PlayerPrefs.GetString ("Right", "d");
		Up = PlayerPrefs.GetString ("Up", "w");
		Down = PlayerPrefs.GetString ("Down", "s");
		Interact = PlayerPrefs.GetString ("Interact", "e");
		Inventory = PlayerPrefs.GetString ("Inventory", "tab");
		Skip = PlayerPrefs.GetString ("Skip", "space");
	}
	
	void AddQuestResets(){
		ResetQuests += SampleQuest.Reset;
	}
}
