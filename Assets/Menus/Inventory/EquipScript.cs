using UnityEngine;
using System.Collections;

public class EquipScript : MonoBehaviour {
	public object obj;
	public void Click() {
		((IEquippable)obj).Equip();
	}
}
