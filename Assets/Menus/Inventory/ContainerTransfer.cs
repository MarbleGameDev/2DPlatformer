using UnityEngine;
using System.Collections;

public class ContainerTransfer : MonoBehaviour {
	public Transform container;
	public void Click(){
		if (container != null) {
			container.GetComponent<GenericChest>().RemoveItem(this.transform.name.Remove(this.transform.name.Length - 1));
			//Debug.Log(this.transform.name.Remove(this.transform.name.Length - 1));
		}
	}
}
