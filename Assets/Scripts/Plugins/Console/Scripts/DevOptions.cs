using UnityEngine;
using System.Collections;

public class DevOptions : MonoBehaviour {
	public bool noclip;
	public bool fly;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool getFly(){
		return fly;
	}
	public bool getNoClip(){
		return noclip;
	}
}
