using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float movementModifier;
	public float verticalModifier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float inputUp = Input.GetAxis("Vertical");
		float inputSide = Input.GetAxis ("Horizontal");
		
		if (inputSide > 0){
			transform.Translate(Vector2.right * movementModifier);
		}
		if (inputSide < 0){
			transform.Translate(Vector2.left * movementModifier);
		}
		if (inputUp > 0) {
			transform.Translate(Vector2.up * verticalModifier);
		}
	}
}
