using UnityEngine;
using System.Collections;

public class CreateItemObject : MonoBehaviour {
    [System.Serializable]
    public class Items {
        public string itemName;
        public int itemAmount;
        public string description;
        [Header("Options for setting weapon data")]
        public float damage;
        public float swingSpeed;
        public float range;
        public string name;
		[Header("Cost used with Shop Inventories")]
		public int cost;
    }
    public Items[] ItemObjects;
	/// <summary>
	/// Adds the Items specified in the Inspector-editable arrays and adds them to the inventory object on its gameobject
	/// </summary>
    public void AddItems() {
        Inventory chest = gameObject.GetComponent<Inventory>();
        if (chest != null) {
            foreach (Items itm in ItemObjects) {
                Iitem objItem = (Iitem)ItemDictionary.itemDict.GetItem(itm.itemName);
				if (objItem != null) {
					if (!itm.description.Equals(""))
						objItem.Description = itm.description;
					if (objItem is IWeapon) {
						IWeapon objWeap = (IWeapon)objItem;
						if (itm.damage > 0)
							objWeap.damage = itm.damage;
						if (itm.swingSpeed > 0)
							objWeap.swingSpeed = itm.swingSpeed;
						if (itm.range > 0)
							objWeap.range = itm.range;
						if (!itm.name.Equals(""))
							objWeap.Name = itm.name;
						chest.AddObject(objWeap, itm.itemAmount);
					} else {
						chest.AddObject(objItem, itm.itemAmount);
					}
					if (chest is GenericShop) {    //If the chest is a shop instance
						((GenericShop)chest).itemCost.Add(objItem, itm.cost);
					}
				}
            }
			chest.SaveInventory();
        }
    }

}
