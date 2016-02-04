using UnityEngine;
using System.Collections;

public class EatScript : MonoBehaviour {
	public object obj;
	public void Click() {
		((IFood)obj).Eat();
	}
}
