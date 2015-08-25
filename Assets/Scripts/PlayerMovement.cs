using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float movementModifier;
	public float verticalModifier;
	public bool canJump;
	//public float test = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//test = test + 0.1;
		float inputUp = Input.GetAxis("Vertical");
		float inputSide = Input.GetAxis ("Horizontal");
		
		if (inputSide > 0){
			transform.Translate(Vector2.right * movementModifier);
		}
		if (inputSide < 0){
			transform.Translate(Vector2.left * movementModifier);
		}
		if (inputUp > 0 && canJump == true){
			transform.Translate(Vector2.up * verticalModifier);
		}
		canJump = false;
		//print (Mathf.Exp (test));
	}
	void OnCollisionStay2D (Collision2D col)
	{

		if (col.gameObject.tag == "Terrain") {
			canJump = true;

		}

	}
}
