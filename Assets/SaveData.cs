using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {
	public delegate void resetData();
	public static event resetData ResetInv;

	public static int gameHours, gameDays;
	
	public static string EquippedItem = "Hands";

	public static string currentQuest = "";

	public static string playerName = "Joshabar";

	public static string Left, Right, Up, Down, Interact, Inventory, Skip, Minimap;
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
        QuestDictionary.Reset();
		StoreData ();
	}
    public static void ResetEverything() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
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
		PlayerPrefs.SetString ("equippedItem", EquippedItem);
		PlayerPrefs.SetString ("currentQuest", currentQuest);
		PlayerPrefs.SetString ("Left", Left);
		PlayerPrefs.SetString ("Right", Right);
		PlayerPrefs.SetString ("Up", Up);
		PlayerPrefs.SetString ("Down", Down);
		PlayerPrefs.SetString ("Interact", Interact);
		PlayerPrefs.SetString ("Inventory", Inventory);
		PlayerPrefs.SetString ("Skip", Skip);
		PlayerPrefs.SetString ("Minimap", Minimap);
		PlayerPrefs.Save ();
	}

	public static void GetData(){
		gameHours = PlayerPrefs.GetInt ("gameHours", 8);
		gameDays = PlayerPrefs.GetInt ("gameDays", 0);
		EquippedItem = PlayerPrefs.GetString ("equippedItem", "hands");
		currentQuest = PlayerPrefs.GetString ("currentQuest");
		Left = PlayerPrefs.GetString ("Left", "a");
		Right = PlayerPrefs.GetString ("Right", "d");
		Up = PlayerPrefs.GetString ("Up", "w");
		Down = PlayerPrefs.GetString ("Down", "s");
		Interact = PlayerPrefs.GetString ("Interact", "e");
		Inventory = PlayerPrefs.GetString ("Inventory", "tab");
		Skip = PlayerPrefs.GetString ("Skip", "space");
		Minimap = PlayerPrefs.GetString("Minimap", "left shift");
	}
}
