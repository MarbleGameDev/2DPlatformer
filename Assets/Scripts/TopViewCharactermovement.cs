using UnityEngine;
using System.Collections;

public class TopViewCharactermovement : MonoBehaviour {
	public float horizontalVelocity;
	public float verticalVelocity;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		horizontalVelocity = Input.GetAxis ("Horizontal");
		verticalVelocity = Input.GetAxis ("Vertical");
		
		transform.Translate (horizontalVelocity/50, verticalVelocity/50, 0);
	
	}
}
