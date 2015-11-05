﻿using UnityEngine;
using System.Collections;

public class StretchPanel : MonoBehaviour {
	public int width = 160;
	Transform items;
	// Use this for initialization
	void Start () {
		items = this.transform.Find("Items");
		GetComponent<RectTransform>().sizeDelta = new Vector2(width,(items.transform.childCount * 30));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
