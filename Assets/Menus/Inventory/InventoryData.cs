using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

public class InventoryData : MonoBehaviour {

    public static Dictionary<object, int> itemCount = new Dictionary<object, int>();
    public static List<object> items = new List<object>();
    public static int equippedItem;

	public delegate void InvChanged();
	public static event InvChanged OnChange;
    public static void equipItem(object obj) {
        if (HasItem(obj)) {
            foreach (object e in items) {
                if (obj is IWeapon) {
                    if (e is IWeapon) {
                        if (((IWeapon)e).ID.Equals(((IWeapon)obj).ID)) {
                            equippedItem = items.IndexOf(e);
                            JsonFile.save.PlayerData.EquippedItem = equippedItem;
							SaveData.queueSave = true;
                        }
                    }
                } else {
                    if (e.ToString().Equals(obj.ToString())) {
                        equippedItem = items.IndexOf(e);
                        JsonFile.save.PlayerData.EquippedItem = equippedItem;
						SaveData.queueSave = true;
                    }
                }
            }
        }
        if (OnChange != null)
            OnChange();
    }

    public static float Attack() {
        if (equippedItem == -1) {
            return new Hands().Attack();
        } else {
        if (items[equippedItem] is IWeapon)
            return ((IWeapon)(items[equippedItem])).damage;
        return 0f;
        }
	}
    public static float Cooldown() {
        if (getEquipped() is IWeapon)
            return ((IWeapon)(items[equippedItem])).swingSpeed;
        return 0f;
    }
    public static float Range() {
        if (getEquipped() is IWeapon) {
            if (getEquipped() is Hands) {
                return new Hands().range;
            }
            return (((IWeapon)(items[equippedItem])).range);
        }
        return 0f;
    }
    public static void UseItem(object obj) {
        if (HasItem(obj)) {
            ((Iitem)obj).Use();
        }
    }
    public static void DropItem(object obj) {
        if (HasItem(obj)) {
            ((Iitem)obj).Drop();
        }
    }
    public static object getEquipped() {
        if (equippedItem == -1) {
            return new Hands();
        }
        if (items[equippedItem] != null)
            return items[equippedItem];
        return new Hands();
    }

    public static object GetItem(string name) {
        foreach (object e in items) {
            if (e.ToString().Equals(name))
                return e;
        }
        return null;
    }

    public static bool HasItem(object obj){
		if (obj != null) {
			foreach (object e in items) {
				if (obj is IWeapon) {
					if (e is IWeapon) {
						if (((IWeapon)e).ID.Equals(((IWeapon)obj).ID)) {
							return true;
						}
					}
				} else {
					if (e.ToString().Equals(obj.ToString())) {
						return true;
					}
				}
			}
		}
        return false;
	}

    public static bool compareItems(object obj1, object obj2) {
        if (obj1 is IWeapon) {
            if (obj2 is IWeapon) {
                if (((IWeapon)obj1).ID.Equals(((IWeapon)obj2).ID)) {
                    return true;
                }
            }
        } else {
            if (obj1.ToString().Equals(obj2.ToString())) {
                return true;
            }
        }
        return false;
    }

	public static void UpdateInv(){
		OnChange ();
	}

	public static void Awake (){
		SaveData.ResetInv += ResetInv;
		GetInventory ();
	}


	public static void ResetInv(){
		itemCount.Clear ();
        items.Clear();
		if (OnChange != null)
			OnChange();
		equippedItem = -1;
		JsonFile.save.PlayerData.EquippedItem = equippedItem;
		SaveInventory();
	}

	public static void SaveInventory(){
		if (items.Count > 0) {
			int y = 0;
			int[] count = new int[itemCount.Count];
			JsonFile.save.PlayerData.inventoryItems.Clear();
			foreach (object e in items) {
				JsonFile.save.PlayerData.inventoryItems.Insert(y, SaveData.SerializeObject(e));
				count[y] = itemCount[e];
				y++;
			}
			JsonFile.save.PlayerData.inventoryCount = count;
			JsonFile.save.PlayerData.inventoryLength = items.Count;
			JsonFile.save.PlayerData.EquippedItem = equippedItem;
			JsonFile.WriteData();
		} else {
			JsonFile.save.PlayerData.inventoryItems.Clear();
			JsonFile.save.PlayerData.inventoryCount = new int[0];
			JsonFile.save.PlayerData.inventoryLength = 0;
			JsonFile.WriteData();
		}
	}
    public static void GetInventory() {
        items.Clear();
        itemCount.Clear();
		equippedItem = JsonFile.save.PlayerData.EquippedItem;
		int invLength = JsonFile.save.PlayerData.inventoryLength;
		int[] count = JsonFile.save.PlayerData.inventoryCount;
        if (invLength > 0 && count.Length > 0) {
			int i = 0;
			object[] invItems = JsonFile.save.PlayerData.inventoryItems.ToArray();
            foreach (object itm in invItems) {
                AddObject(SaveData.DeSerializeObject((string)itm), count[i]);
            }
        }
		
    }

    private static void AddObject(object obj, int number) {
		if (number > 0) {
			if (HasItem(obj)) {
				object[] entries = items.ToArray();
				foreach (object e in entries) {
					if (obj is IWeapon) {
						if (e is IWeapon) {
							if (((IWeapon)e).ID.Equals(((IWeapon)obj).ID)) {
								itemCount[e] += number;
							}
						}
					} else {
						if (e.ToString().Equals(obj.ToString())) {
							if (((Iitem)e).Description.Equals(((Iitem)obj).Description)) {
								itemCount[e] += number;
							} else {
								items.Add(obj);
								itemCount[obj] = number;
							}
						}
					}
				}
			} else {
				items.Add(obj);
				itemCount[obj] = number;
			}
			SaveInventory();
		}
    }

    public static void AddItem (object name, int number){
		if (name is Iitem) {
            AddObject(name, number);
			if (!HasItem (name)) {
				NotificationManager.AddNotification ("New Item", number + "x " + name);
			} else {
				NotificationManager.AddNotification ("New Item", "+" + number + "x " + name);
			}
			if (OnChange != null)
				OnChange ();
		}
	}

	public static bool RemoveItem (object name, int number){
		if (HasItem (name) && (itemCount[name] - number >= 0)) {
			itemCount [name] -= number;
			if (itemCount[name] == 0){
				itemCount.Remove(name);
                items.Remove(name);
                if (compareItems(items[equippedItem], name)) {
                    equippedItem = -1;
                }
			}
			if (OnChange != null)
				OnChange ();
			SaveInventory ();
			return true;
		} else {
			return false;
		}
	}
	public static bool RemoveItem(string name, int number) {
		foreach (object e in items) {
			if (e.ToString().Equals(name)) {
				return RemoveItem(e, number);
			}
		}
		return false;
	}

}
