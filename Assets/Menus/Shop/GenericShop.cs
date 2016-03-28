using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GenericShop : MonoBehaviour, Inventory {
	MenuManager menu;
	Text infoTxt;
	GameObject names;
	public bool Enabled;
	public string shopIdentifier;
	public Text item;
	public Transform shopWindow;
	public Transform buyBox;

	public List<object> items = new List<object>();
	public Dictionary<object, int> itemCount = new Dictionary<object, int>();
	public Dictionary<object, int> itemCost = new Dictionary<object, int>();

	void Awake() {
		SaveData.ResetInv += ResetInv;
	}

	void Start() {
		if (this != null) {
			menu = GameObject.Find("Main Canvas").GetComponent<MenuManager>();
			if (JsonFile.save.Shops.shopEnabled.ContainsKey(shopIdentifier)) {
				Enabled = JsonFile.save.Shops.shopEnabled[shopIdentifier];
			} else {
				JsonFile.save.Shops.shopEnabled.Add(shopIdentifier, true);
			}
			if (Enabled) {
				CreateItemObject itmobj = GetComponent<CreateItemObject>();
				if (itmobj != null) {
					itmobj.AddItems();
					Enabled = false;
					JsonFile.save.Shops.shopEnabled[shopIdentifier] = Enabled;
					SaveData.queueSave = true;
				}
				SaveInventory();
			} else {
				GetInventory();
			}
		}
	}

	public void OpenWindow() {
		if (!MenuManager.windowOpen) {
			menu.OpenCustomWindow(shopWindow);
			SetupShop();
		} else if (MenuManager.windowOpen) {
			menu.CloseWindow();
		}
	}

	public void SetupShop() {
		ShopMenu spmu = GameObject.Find("ShopMenu(Clone)").GetComponent<ShopMenu>();
		spmu.shop = this;
		names = GameObject.Find("ShopItems");
		infoTxt = GameObject.Find("InfoText").GetComponent<Text>();
		DrawInv();
	}

	public void DrawInv() {
		if (names != null) {
			foreach (object entry in items) {
				((Iitem)entry).Cost = itemCost[entry];
				Text newItem = Instantiate(item);
				newItem.transform.SetParent(names.transform, false);
				newItem.text = " " + ((itemCount[entry] > 1) ? ("" + itemCount[entry] + "x ") : ("")) + entry.ToString();
				newItem.name = entry.ToString() + "1";
				newItem.GetComponent<ItemExecution>().item = entry;
			}
		}
	}

	public void AddObject(object obj, int num) {
		items.Add(obj);
		itemCount[obj] = num;
	}

	public void BuyItem(object obj) {
		if (items.Contains(obj) && itemCount.ContainsKey(obj) && itemCount[obj] > 0) {
			if (!InventoryData.hasEnoughGold(((Iitem)obj).Cost))
				return;
			InventoryData.AddItem(obj, 1);
			InventoryData.removeGold(((Iitem)obj).Cost);
			SaveData.queueSave = true;
			itemCount[obj]--;
			if (itemCount[obj] == 0) {
				itemCount.Remove(obj);
				items.Remove(obj);
				infoTxt.text = "";
			}
			UpdateInv();
		}
	}

	void UpdateInv() {
		if (MenuManager.windowOpen) {
			if (names != null && names.transform.childCount > 0) {
				var children = new List<GameObject>();
				foreach (Transform child in names.transform)
					children.Add(child.gameObject);
				children.ForEach(child => Destroy(child));
			}
			DrawInv();
		}
	}

	public void SaveInventory() {
		if (JsonFile.save.Shops.ShopData.ContainsKey(shopIdentifier)) {
			JsonFile.save.Shops.ShopData[shopIdentifier] = new Save.shopsData();
		} else {
			JsonFile.save.Shops.ShopData.Add(shopIdentifier, new Save.shopsData());
		}
		if (items.Count > 0) {
			int y = 0;
			int[] count = new int[itemCount.Count];
			foreach (object e in items) {
				JsonFile.save.Shops.ShopData[shopIdentifier].inventoryItems.Insert(y, SaveData.SerializeObject(e));
				count[y] = itemCount[e];
				y++;
			}
			JsonFile.save.Shops.ShopData[shopIdentifier].inventoryCount = count;
			JsonFile.save.Shops.ShopData[shopIdentifier].inventoryLength = items.Count;
			JsonFile.WriteData();
		} else {
			JsonFile.save.Shops.ShopData[shopIdentifier].inventoryLength = 0;
			JsonFile.WriteData();
		}
	}
	public void GetInventory() {
		items.Clear();
		itemCount.Clear();
		if (JsonFile.save.Shops.ShopData.ContainsKey(shopIdentifier)) {
			int invLength = JsonFile.save.Shops.ShopData[shopIdentifier].inventoryLength;
			int[] count = JsonFile.save.Shops.ShopData[shopIdentifier].inventoryCount;
			if (invLength > 0 && count.Length > 0) {
				int i = 0;
				object[] invItems = JsonFile.save.Shops.ShopData[shopIdentifier].inventoryItems.ToArray();
				foreach (object itm in invItems) {
					AddObject(SaveData.DeSerializeObject((string)itm), count[i]);
				}
			}
		}
	}

	void ResetInv() {
		Enabled = true;
		try {
			JsonFile.save.Shops.shopEnabled[shopIdentifier] = true;
		} catch (Exception) { }
		items.Clear();
		itemCount.Clear();
		itemCost.Clear();
		Start();
	}
}
