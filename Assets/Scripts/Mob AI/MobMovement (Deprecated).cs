using UnityEngine;
using System.Collections;
using System;

public class MobMovement : MonoBehaviour {
	public float movementSpeed = 10f;
	public Vector3 targetPos;
	public GameObject target;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody2D> ();
	}

	public void SetTargetPos(){
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = target.transform.position;
		float distance = Vector3.Distance (transform.position, targetPos);
		if (distance < 20f) {
			//Code for movement
			string direction = "";
			if (Mathf.Acos((Mathf.Abs(transform.position.y - targetPos.y))/distance) > Mathf.Asin((Mathf.Abs(transform.position.y - targetPos.y))/distance) + 1.5f){
				if (transform.position.x > targetPos.x){
					direction = "left";
				}else{
					direction = "right";
				}
			}else{
				if (transform.position.y > targetPos.y){
					direction = "down";
				}else{
					direction = "up";
				}
			}

			if (direction.Equals("left")) {
				if (rb.velocity.x > -movementSpeed) {
					rb.velocity = new Vector2 (rb.velocity.x - 2f, 0);
				}
			} else if (direction.Equals("right")) {
				if (rb.velocity.x < movementSpeed) {
					rb.velocity = new Vector2 (rb.velocity.x + 2f, 0);
				}
			} else if (direction.Equals("up")) {
				if (rb.velocity.y < movementSpeed) {
					rb.velocity = new Vector2 (0, rb.velocity.y + 2f);
				}
			} else if (direction.Equals("down")) {
				if (rb.velocity.y > -movementSpeed) {
					rb.velocity = new Vector2 (0, rb.velocity.y - 2f);
				}
			} else {
				if (Math.Floor (rb.velocity.y) != 0) {
					rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
				} else {
					rb.velocity = new Vector2 (0, 0);
				}
			}
		}else{
			if (Math.Floor (rb.velocity.y) != 0) {
				rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
			} else {
				rb.velocity = new Vector2 (0, 0);
			}
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if (!coll.transform.tag.Equals ("Player")) {
			Debug.Log ("ReRouting");
			targetPos = target.transform.position;
			float distance = Vector3.Distance (transform.position, targetPos);
			if (distance < 20f) {
				//Code for movement
				string direction = "";
				RaycastHit2D left = Physics2D.Raycast (transform.position, new Vector2 (-1, 0), 100f, LayerMask.NameToLayer("Background"));
				RaycastHit2D right = Physics2D.Raycast (transform.position, new Vector2 (1, 0), 100f, LayerMask.NameToLayer("Background"));
				RaycastHit2D up = Physics2D.Raycast (transform.position, new Vector2 (0, 1), 100f, LayerMask.NameToLayer("Background"));
				RaycastHit2D down = Physics2D.Raycast (transform.position, new Vector2 (0, -1), 100f, LayerMask.NameToLayer("Background"));
				Debug.Log("Left " + left.distance);
				Debug.Log("Right " + right.distance);
				Debug.Log("Up " + up.distance);
				Debug.Log("Down " + down.distance);
				if (left.distance < .1f || right.distance < .1f) {
					if (up.distance >= down.distance) {
						direction = "up";
					} else {
						direction = "down";
					}
				} else if (up.distance < .1f || down.distance < .1f) {
					if (left.distance >= right.distance){
						direction = "left";
					}else{
						direction = "right";
					}
				}
				Debug.Log(direction);
				if (direction.Equals ("left")) {
					if (rb.velocity.x > -movementSpeed) {
						rb.velocity = new Vector2 (rb.velocity.x - 2f, 0);
					}
				} else if (direction.Equals ("right")) {
					if (rb.velocity.x < movementSpeed) {
						rb.velocity = new Vector2 (rb.velocity.x + 2f, 0);
					}
				} else if (direction.Equals ("up")) {
					if (rb.velocity.y < movementSpeed) {
						rb.velocity = new Vector2 (0, rb.velocity.y + 2f);
					}
				} else if (direction.Equals ("down")) {
					if (rb.velocity.y > -movementSpeed) {
						rb.velocity = new Vector2 (0, rb.velocity.y - 2f);
					}
				} else {
					if (Math.Floor (rb.velocity.y) != 0) {
						rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
					} else {
						rb.velocity = new Vector2 (0, 0);
					}
				}
			} else {
				if (Math.Floor (rb.velocity.y) != 0) {
					rb.velocity = new Vector2 (rb.velocity.x / 2, rb.velocity.y / 2);
				} else {
					rb.velocity = new Vector2 (0, 0);
				}
			}
		}
	}
}
