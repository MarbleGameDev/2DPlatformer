using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Save {
	public controls Controls = new controls();
	public gameData GameData = new gameData();
	public playerData PlayerData = new playerData();
	public inventories Inventories = new inventories();
	public questData Quests = new questData();

	public class controls {
		public string Left = "a", Right = "d", Up = "w", Down = "s", Interact = "e", Inventory = "tab", Skip = "space", Minimap = "left shift";     //Key bindings
	}
	public class gameData {
		public int gameHours = 12, gameDays;
	}
	public class playerData {
		public int EquippedItem = -1;
		public string playerName = "Joshabar";
		public string currentQuest = "";
		public ArrayList inventoryItems = new ArrayList();
		public int[] inventoryCount;
		public int inventoryLength;
	}
	public class inventoryData {
		public ArrayList inventoryItems = new ArrayList();
		public int[] inventoryCount;
		public int inventoryLength;
	}
	public class inventories {
		public Dictionary<string, bool> inventoryEnabled = new Dictionary<string, bool>();
		public Dictionary<string, inventoryData> InventoryData = new Dictionary<string, inventoryData>();
	}
	public class questData {
		public Dictionary<string, object[]> QuestData = new Dictionary<string, object[]>();
	}

}
