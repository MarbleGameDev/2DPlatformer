using UnityEngine;
using System.Collections;
using System;

public class TopViewCharactermovement : MonoBehaviour {
	private float horizontalMax = 10f;
	Rigidbody2D rb;
	Health hel;
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
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!MenuManager.windowOpen) {
			if (!up && !down)
				left = Input.GetButton ("Left");
			if (!up && !down)
				right = Input.GetButton ("Right");
			if (!left && !right)
				up = Input.GetButton ("Up");
			if (!left && !right)
				down = Input.GetButton ("Down");
		} else {
			up = false;
			down = false;
			left = false;
			right = false;
		}

		if (Input.GetButtonDown ("Attack")) {
			Vector2 dir = new Vector2(0,0);
			switch (direction){
			case 1:
				dir = new Vector2(-1, 0);
				break;
			case 2:
				dir = new Vector2(1, 0);
				break;
			case 3:
				dir = new Vector2(0, 1);
				break;
			case 4:
				dir = new Vector2(0, -1);
				break;
			}
			RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1f, dir, 2f, LayerMask.GetMask("Background")); 	//Change layer to enemy layer later
			if (hit.transform != null){
				Debug.Log (hit.transform);
				if ((hel = hit.transform.GetComponent<Health>()) != null){
					hel.Damage(InventoryData.Attack());
				}
			}
		}

		if (left) {
			direction = 1;
			if (rb.velocity.x > -horizontalMax) {
				rb.velocity = new Vector2 (rb.velocity.x - 2f, 0);
			}
			anim.Play ("Walking Left");
		} else if (right) {
			direction = 2;
			if (rb.velocity.x < horizontalMax) {
				rb.velocity = new Vector2 (rb.velocity.x + 2f, 0);
			}
			anim.Play ("Walking Right");
		} else if (up) {
			direction = 3;
			if (rb.velocity.y < horizontalMax) {
				rb.velocity = new Vector2 (0, rb.velocity.y + 2f);
			}
			anim.Play ("Walking Up");
		} else if (down) {
			direction = 4;
			if (rb.velocity.y > -horizontalMax) {
				rb.velocity = new Vector2 (0, rb.velocity.y - 2f);
			}
			anim.Play ("Walking Down");
		} else {
			if (Math.Floor (rb.velocity.y) != 0) {
				rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
			} else {
				rb.velocity = new Vector2 (0, 0);
			}
			switch (direction) {
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
	}

}
