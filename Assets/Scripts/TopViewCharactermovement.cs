using UnityEngine;
using System.Collections;
using System;

public class TopViewCharactermovement : MonoBehaviour {
	private float horizontalMax = 10f;
	private float jumpVelocity = 30;


	Rigidbody2D rb;
	DevOptions dev;
	PolygonCollider2D col;


	public bool collisionLeft;
	public bool collisionRight;
	public bool collisionUp;
	public bool collisionDown;
	private float gravityScale;

	int direction;

	private bool left;
	private bool right;
	private bool up;
	private bool down;
	private bool horizontal;
	

	Animator anim;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		dev = GetComponent<DevOptions> ();
		col = GetComponent<PolygonCollider2D>();
		gravityScale = rb.gravityScale;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!up && !down)
		left = Input.GetButton ("Left");
		if (!up && !down)
		right = Input.GetButton ("Right");
		if (!left && !right)
		up = Input.GetButton ("Up");
		if (!left && !right)
		down = Input.GetButton ("Down");

		if (left && !collisionLeft) {
			direction = 1;
			if (rb.velocity.x > -horizontalMax) {
				rb.velocity = new Vector2 (rb.velocity.x - 2f, 0);
			}
			anim.Play ("Walking Left");
		} else if (right && !collisionRight) {
			direction = 2;
			if (rb.velocity.x < horizontalMax) {
				rb.velocity = new Vector2 (rb.velocity.x + 2f, 0);
			}
			anim.Play("Walking Right");
		}else if (up && !collisionUp) {
			direction = 3;
			if (rb.velocity.y < horizontalMax) {
				rb.velocity = new Vector2 (0, rb.velocity.y + 2f);
			}
			anim.Play("Walking Up");
		} else if (down && !collisionDown) {
			direction = 4;
			if (rb.velocity.y > -horizontalMax) {
				rb.velocity = new Vector2 (0, rb.velocity.y - 2f);
			}
			anim.Play("Walking Down");
		} else {
			if (Math.Floor (rb.velocity.y) != 0) {
				rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
			} else {
				rb.velocity = new Vector2 (0, 0);
			}
			Debug.Log (direction);
			switch (direction){
			case 1:
				anim.Play ("StandLeft");
				break;
			case 2:
				anim.Play ("StandRight");
				break;
			case 3:
				anim.Play ("StandUp");
				break;
			case 4:
				anim.Play ("StandDown");
				break;
			}

		}
		
		//Changing Stuff
		collisionLeft = false;
		collisionRight = false;
		collisionUp = false;
		collisionDown = false;
	}

}
