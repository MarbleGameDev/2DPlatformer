using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float verticalModifier;
	Vector2 movementDirection = new Vector2(0,0);
	Rigidbody2D rb;
	DevOptions dev;
	PolygonCollider2D col;
	bool isGrounded;
	bool isCollided;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		dev = GetComponent<DevOptions> ();
		col = GetComponent<PolygonCollider2D>();
	}
	// Update is called once per frame
	void Update () {
		bool noclip = dev.noclip;
		bool fly = dev.fly;
		bool debug = dev.debug;
		if (Input.GetButton ("Jump") && isGrounded) {
			movementDirection.y = 3;
		} else {
			movementDirection.y = -.05f;
		}
		if (Input.GetButton ("Left")) {
			movementDirection.x = -.5f;
		}
		if (Input.GetButton ("Right")) {
			movementDirection.x = .5f;
		}
		if ((Mathf.Abs (rb.velocity.x) < 30)) {
			rb.AddForce (movementDirection * verticalModifier, ForceMode2D.Impulse);
		} else if (movementDirection.y > 0 || fly || noclip) {
			rb.AddForce (new Vector2 (0, movementDirection.y) * verticalModifier, ForceMode2D.Impulse);
		}
		if (debug) {
			Debug.Log (rb.velocity);
		}
		movementDirection.x = 0;
		movementDirection.y = 0;
		isGrounded = false;
		isCollided = false;
	}

	void OnCollisionStay2D (Collision2D col){
		ContactPoint2D contact = col.contacts [0]; 
		if (Vector2.Dot (contact.normal, Vector2.up) > 0.2) {
			isGrounded = true;
		} else {
			isCollided = true;
		}
	}
}
