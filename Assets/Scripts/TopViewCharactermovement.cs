using UnityEngine;
using System.Collections;
using System;

public class TopViewCharactermovement : MonoBehaviour {
	public AudioClip deathSound;
	public Sprite leftSprite;
	public Sprite rightSprite;
	private float horizontalMax = 10f;
	private float jumpVelocity = 30;
	Rigidbody2D rb;
	DevOptions dev;
	PolygonCollider2D col;
	public bool isGrounded;
	public bool collisionLeft;
	public bool collisionRight;
	public bool collisionUp;
	public bool collisionDown;
	private float gravityScale;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		dev = GetComponent<DevOptions> ();
		col = GetComponent<PolygonCollider2D>();
		gravityScale = rb.gravityScale;
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool noclip = dev.noclip;
		bool fly = dev.fly;
		bool debug = dev.debug;
		if (Input.GetButton ("Left") || Input.GetButton ("Right") || Input.GetButton ("Up") || Input.GetButton ("Down")) {
			if (Input.GetButton ("Left") && !collisionLeft) {
				if (rb.velocity.x > -horizontalMax) {
					rb.velocity = new Vector2 (rb.velocity.x - 2f, rb.velocity.y);
				}
				sprite.sprite = leftSprite;
			} else if (Input.GetButton ("Right") && !collisionRight) {
				if (rb.velocity.x < horizontalMax) {
					rb.velocity = new Vector2 (rb.velocity.x + 2f, rb.velocity.y);
				}
				sprite.sprite = rightSprite;
			} else {
				if (Math.Floor (rb.velocity.x) != 0) {
					rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y);
				}
			}
			if (Input.GetButton ("Up") && !collisionUp) {
				if (rb.velocity.y < horizontalMax) {
					rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y + 2f);
				}
			} else if (Input.GetButton ("Down") && !collisionDown) {
				if (rb.velocity.y > -horizontalMax) {
					rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y - 2f);
				}
			} else {
				if (Math.Floor (rb.velocity.y) != 0) {
					rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y / 2);
				}
			}
		}else{
			rb.velocity = new Vector2 (0,0);
		}
		if (debug) {
			Debug.Log (rb.velocity);
		}

		
		//Changing Stuff
		isGrounded = false;
		collisionLeft = false;
		collisionRight = false;
		collisionUp = false;
		collisionDown = false;
	}

}
