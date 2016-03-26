using UnityEngine;
using System.Collections;

public class BuyScript : MonoBehaviour {
	GenericShop shop;
	public object obj;
	public void Click() {
		shop.BuyItem(obj);
	}
	void Start() {
		if (((Iitem)obj).Cost > InventoryData.gold)
			gameObject.SetActive(false);
		shop = GameObject.Find("ShopMenu(Clone)").GetComponent<ShopMenu>().shop;
	}
	void Update() {
		
	}
}
