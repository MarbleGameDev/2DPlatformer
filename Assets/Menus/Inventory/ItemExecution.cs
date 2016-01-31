using UnityEngine;
using System.Collections;

public class ItemExecution : MonoBehaviour {
    public object item;
	public void Click(){
		InventoryData.UseItem (item);
	}
}
