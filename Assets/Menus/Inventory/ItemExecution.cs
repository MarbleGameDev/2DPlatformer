using UnityEngine;
using System.Collections;

public class ItemExecution : MonoBehaviour {

	public void Click(){
		ItemDictionary.UseItem (transform.name.TrimEnd('1'));
	}
}
