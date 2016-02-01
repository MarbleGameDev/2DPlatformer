using UnityEngine;
using System.Collections;
using System;

public class TopViewCharactermovement : MonoBehaviour {
	private float horizontalMax = 10f;
	Rigidbody rb;
	Health hel;
	int direction = 5;

	public bool left = false;
	public bool right = false;
	public bool up = false;
	public bool down = false;
	private bool horizontal;
    private bool attacking;

	Animator anim;

    private float attackCooldown = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
        InvokeRepeating("Cooldown", 0f, .1f);
	}

    void Cooldown() {
        if (attackCooldown > 0) {
            attackCooldown -= 1;
        } else {
            attackCooldown = 0;
        }
    }

    void Update() {
        //Attack Code
        if (Input.GetButtonDown("Attack") && !MenuManager.windowOpen){
            Vector2 dir = new Vector2(0, 0);
            switch (direction)
            {
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
            attacking = true;
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1f, dir, InventoryData.Range(), LayerMask.GetMask("Enemy"));   //Change layer to enemy layer later
            if (hit.transform != null && attacking && attackCooldown == 0)
            {
                if ((hel = hit.transform.GetComponent<Health>()) != null)
                {
                    attackCooldown = InventoryData.Cooldown();
                    hel.Damage(InventoryData.Attack());
                    attacking = false;
                }
            }
        }
    }
	
	void FixedUpdate () {

		//Checked movement and deals with movement in only one direction at a time
		if (!MenuManager.windowOpen) {
			if (!up && !down)
				left = Input.GetKey (InputManager.GetKey("Left"));
			if (!up && !down)
				right = Input.GetKey(InputManager.GetKey("Right"));
			if (!left && !right)
				up = Input.GetKey (InputManager.GetKey("Up"));
			if (!left && !right)
				down = Input.GetKey (InputManager.GetKey("Down"));
		} else {
			up = false;
			down = false;
			left = false;
			right = false;
        }

		//Fix movement if the character gets bumped into a diagonal trajectory
		if (rb.velocity.x != 0 && rb.velocity.y != 0) {
			if (Mathf.Abs(rb.velocity.y) >= Mathf.Abs(rb.velocity.x)){
				rb.velocity = new Vector2(0, rb.velocity.y);
			}else{
				rb.velocity = new Vector2(rb.velocity.x, 0);
			}
		}

		//Movement Direction Code and Animation Playing
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
