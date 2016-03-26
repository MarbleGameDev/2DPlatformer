using UnityEngine;
using System.Collections;

public interface Inventory {
	void AddObject(object objWeap, int itemAmount);
	void SaveInventory();
	void GetInventory();
}
