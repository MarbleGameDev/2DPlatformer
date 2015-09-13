using UnityEngine;
using System.Collections;
using System;

public class CharacterMovement : MonoBehaviour {
	public AudioClip deathSound;
	public int terminalVelocity;
	public int horizontalMax;
	private float jumpVelocity = 30;
	Rigidbody2D rb;
	DevOptions dev;
	PolygonCollider2D col;
	public bool isGrounded;
	public bool collisionLeft;
	public bool collisionRight;
	private float gravityScale;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		dev = GetComponent<DevOptions> ();
		col = GetComponent<PolygonCollider2D>();
		gravityScale = rb.gravityScale;
	} 
	// Update is called once per frame
	void Update () {
		bool noclip = dev.noclip;
		bool fly = dev.fly;
		bool debug = dev.debug;
		if (fly || noclip) {
			rb.gravityScale = 0;
			jumpVelocity = 1;
		} else {
			if (rb.gravityScale == 0){
				rb.gravityScale = gravityScale;
			}
			if (jumpVelocity != 30){
				jumpVelocity = 30;
			}
		}
		if (Input.GetButton ("Jump") && (isGrounded || (collisionLeft && rb.velocity.y == 0) || (collisionRight && rb.velocity.y == 0) || fly || noclip)) {
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y + jumpVelocity);
		} else {
			if ((rb.velocity.y > terminalVelocity) && !noclip && !fly){
				rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y - 1);
			}
		}
		if (Input.GetButton ("Left") && !collisionLeft) {
			if (rb.velocity.x > -horizontalMax) {
				rb.velocity = new Vector2 (rb.velocity.x - 10, rb.velocity.y);
			}
		} else if (Input.GetButton ("Right") && !collisionRight) {
			if (rb.velocity.x < horizontalMax) {
				rb.velocity = new Vector2 (rb.velocity.x + 10, rb.velocity.y);
			}
		} else {
			if (Math.Floor(rb.velocity.x) != 0){
				rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y);
			}
		}
		if (debug) {
			Debug.Log (rb.velocity);
		}

		positionChecking ();

		//Changing Stuff
		isGrounded = false;
		collisionLeft = false;
		collisionRight = false;
	}

	void positionChecking (){
		if (transform.position.y < -40) {
			transform.position = new Vector2 (-33, -2);
			AudioSource.PlayClipAtPoint(deathSound,transform.position);
		}
	}
}
