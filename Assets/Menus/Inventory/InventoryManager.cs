using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	Transform content;
	public Text item;
	InventoryData data;
	public Transform names;
	public Transform numbers;
	// Use this for initialization
	void Start () {
		data = GetComponent<InventoryData> ();

		foreach (var entry in InventoryData.inventory) {
			Text newItem = Instantiate(item);
			newItem.transform.SetParent(names, false);
			newItem.text = entry.Key;

			Text newNum = Instantiate(item);
			newNum.transform.SetParent(numbers, false);
			newNum.text = entry.Value.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
