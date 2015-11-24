using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	Transform content;
	public Text item;
	InventoryData data;
	public Transform parent;
	// Use this for initialization
	void Start () {
		data = GetComponent<InventoryData> ();

		foreach (var entry in InventoryData.inventory) {
			Text newItem = Instantiate(item);
			newItem.transform.SetParent(parent, false);
			newItem.text = entry.Key + "\t" + entry.Value;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
