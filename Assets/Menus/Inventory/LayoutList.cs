using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LayoutList : MonoBehaviour {
	RectTransform rect;
	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rect.sizeDelta.y != transform.FindChild("InvNames").childCount * 40) { 	//May not want to use FindChild every time...
			rect.sizeDelta = new Vector2 (rect.sizeDelta.x, transform.FindChild ("InvNames").childCount * 40 + 5);
		}
	}
}
