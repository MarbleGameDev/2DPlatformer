using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Save {
	public controls Controls = new controls();
	public gameData GameData = new gameData();
	public playerData PlayerData = new playerData();
	public inventoryData InventoryData = new inventoryData();
	public questData QuestData = new questData();
	public class controls {
		public string Left, Right, Up, Down, Interact, Inventory, Skip, Minimap;     //Key bindings
	}
	public class gameData {
		public int gameHours, gameDays;
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

	}
	public class questData {

	}

}
