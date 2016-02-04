using UnityEngine;
using System.Collections;

public class ContainerTransfer : MonoBehaviour {
	public Transform container;
	public object item;
	public void Click(){
		if (container != null) {
			container.GetComponent<GenericChest>().TransferItem(item);
		}
	}
}
