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
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		bool inputUp = Input.GetButton("Jump");
		float inputSide = Input.GetAxis ("Horizontal");
		//Needs a movement function for accurate movement, Josh pls do this
		if (inputSide > 0){
			transform.Translate(transform.right * movementModifier);
		}
		if (inputSide < 0){
			transform.Translate(transform.right * movementModifier * -1);
		}
		if (inputUp && canJump){
			rb.AddForce(transform.up * verticalModifier * 100, ForceMode2D.Impulse);
		}
		canJump = false;
	}
	void OnCollisionStay2D (Collision2D col)
	{
		ContactPoint2D contact = col.contacts[0];
		if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
		{
			canJump = true;
		}
		
	}
}
