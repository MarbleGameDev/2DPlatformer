using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class InventoryData : MonoBehaviour {

	public static Dictionary<string, int> inventory = new Dictionary<string, int> ();
	public static string EquippedItem = SaveData.EquippedItem;

	public delegate void InvChanged();
	public static event InvChanged OnChange;
	// Use this for initialization
	void Start () {

	}

	public static float Attack(){
		return ItemDictionary.AttackItem(EquippedItem);
	}
    public static float Cooldown() {
        return ItemDictionary.CooldownItem(EquippedItem);
    }
    public static float Range() {
        return ItemDictionary.RangeItem(EquippedItem);
    }

	public static bool HasItem(string item){
		return inventory.ContainsKey (item);
	}

	public static void UpdateInv(){
		OnChange ();
	}

	public static void Awake (){
		SaveData.ResetInv += ResetInv;
		GetInventory ();
	}


	public static void ResetInv(){
		inventory.Clear ();
		SaveInventory ();
	}

	public static void SaveInventory(){
		if (inventory.Count > 0) {
			string[] invNames = new string[inventory.Count];
			int[] invNums = new int[inventory.Count];
			int y = 0;
			foreach (KeyValuePair<string, int> e in inventory) {
				invNames [y] = e.Key;
				invNums [y] = e.Value;
				y++;
			}
			PlayerPrefsX.SetStringArray ("playerInvNames", invNames);
			PlayerPrefsX.SetIntArray ("playerInvNums", invNums);
		}
	}
	public static void GetInventory(){
		string[] invNames = PlayerPrefsX.GetStringArray("playerInvNames", "", 0);
		int[] invNums = PlayerPrefsX.GetIntArray("playerInvNums", 0, 0);
		inventory.Clear ();
		if (invNames.Length > 0 && invNums.Length > 0) {
			for (int i = 0; i < invNames.Length; i++) {
				inventory.Add (invNames [i], invNums [i]);
			}
		}
	}

	public static void AddItem (string name, int number){
		if (ItemDictionary.itemDict.Contains (name)) {
			if (!HasItem (name)) {
				inventory.Add (name, number);
				//Notification Creation
				NotificationManager.AddNotification ("New Item", number + "x " + name);
			} else {
				inventory [name] += number;
				//Notification Creation
				NotificationManager.AddNotification ("New Item", "+" + number + "x " + name);
			}
			if (OnChange != null)
				OnChange ();
		}
		SaveInventory ();
	}

	public static bool RemoveItem (string name, int number){
		if (HasItem (name) && (inventory [name] - number >= 0)) {
			inventory [name] -= number;
			if (inventory[name] == 0){
				inventory.Remove(name);
			}
			if (OnChange != null)
				OnChange ();
			SaveInventory ();
			return true;
		} else {
			return false;
		}
	}

}
