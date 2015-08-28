using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float movementModifier;
	public float verticalModifier;
	public bool canJump, moveLeft, moveRight;
	public float inputSide;
	Rigidbody2D rb;
	DevOptions dev;
	PolygonCollider2D col;
	//public float test = 1.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		dev = GetComponent<DevOptions> ();
		col = GetComponent<PolygonCollider2D>();
		moveLeft = true;
		moveRight = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool noclip = dev.noclip;
		bool fly = dev.fly;
		if (noclip == true) {
			col.enabled = false;
			rb.gravityScale = 0;
		}
		if (fly == true) {
			rb.gravityScale = 0;
		} else if (fly == false && noclip == false){
			rb.gravityScale = 4;
			col.enabled = true;
		}
		//test = test + 0.1;
		bool inputUp = Input.GetButton("Jump");
		bool inputDown = Input.GetButton("Croutch");
		inputSide = Input.GetAxis ("Horizontal");
		//Needs a movement function for accurate movement, Josh pls do this
		//Check for side collision
		if (inputSide > 0 && moveRight){
			transform.Translate(transform.right * movementModifier);
			moveLeft = true;
			moveRight = true;
		}
		if (inputSide < 0 && moveLeft){
			transform.Translate(transform.right * movementModifier * -1);
			moveRight = true;
			moveLeft = true;
		}
		if (inputUp & canJump & noclip == false && fly == false){
			rb.AddForce(transform.up * verticalModifier * 100, ForceMode2D.Impulse);
			moveRight = true;
			moveLeft = true;
		}
		if (inputUp & (noclip || fly)) {
			transform.Translate(transform.up * .5f);
			moveRight = true;
			moveLeft = true;
		}
		if (inputDown & (noclip || fly)) {
			transform.Translate(transform.up * -.5f);
			moveRight = true;
			moveLeft = true;
		}
		print (canJump);
			canJump = false;
	}
	void OnCollisionStay2D (Collision2D col){
		ContactPoint2D contact = col.contacts[0];
		if(Vector3.Dot(contact.normal, Vector3.up) > 0.1)
		{
			canJump = true;
		}
		if (Vector3.Dot (contact.normal, Vector2.right) > 0.1) {
			moveLeft = false;
		}
		if (Vector3.Dot (contact.normal, Vector2.right) < 0) {
			//moveRight = false;
		}
		//Code maybe to detect side collision for movement?
		
	}
}
