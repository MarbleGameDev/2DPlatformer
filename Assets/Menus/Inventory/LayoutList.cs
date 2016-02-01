using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LayoutList : MonoBehaviour {
	RectTransform rect;
    Transform invNames;
	// Use this for initialization
	void Start () {
		rect = GetComponent<RectTransform> ();
        invNames = transform.FindChild("InvNames");
	}
	
	// Update is called once per frame
	void Update () {
		if (rect.sizeDelta.y != invNames.childCount * 40) { 	//May not want to use FindChild every time...
			rect.sizeDelta = new Vector2 (rect.sizeDelta.x, invNames.childCount * 40 + 20);
		}
	}
}
