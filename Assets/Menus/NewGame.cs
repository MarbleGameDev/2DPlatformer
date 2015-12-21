using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewGame : MonoBehaviour {

	void Start(){
		GetComponent<Button> ().onClick.AddListener (() => {click (); });
	}

	void click(){
		
	}
}
