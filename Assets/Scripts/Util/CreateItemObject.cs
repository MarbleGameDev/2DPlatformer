﻿using UnityEngine;
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
    }
    public Items[] ItemObjects;

    public void Start() {
        GenericChest chest = gameObject.GetComponent<GenericChest>();
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
						chest.AddItem(objWeap, itm.itemAmount);
					} else {
						chest.AddItem(objItem, itm.itemAmount);
					}
				}
            }
        }
    }

}
