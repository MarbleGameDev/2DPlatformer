using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public AudioClip deathSound;
	public float verticalModifier;
	public Vector2 movementDirection = new Vector2(0,0);
	Rigidbody2D rb;
	DevOptions dev;
	PolygonCollider2D col;
	public bool isGrounded;
	public bool collisionLeft;
	public bool collisionRight;
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
		if (Input.GetButton ("Left") && !collisionLeft) {
			if (isGrounded = true){
			movementDirection.x = -.5f;
			}
			//if (isGrounded = false){
			//	movementDirection.x = -.005f;	
			//}
		}
		if (Input.GetButton ("Right") && !collisionRight) {
			if (isGrounded = true){
				movementDirection.x = .5f;
			}
			//if (isGrounded = false){
			//	movementDirection.x = .005f;
			//}
		}
		if ((Mathf.Abs (rb.velocity.x) < 30)) {
			rb.AddForce (movementDirection * verticalModifier, ForceMode2D.Impulse);
		} else if (movementDirection.y > 0 || fly || noclip) {
			rb.AddForce (new Vector2 (0, movementDirection.y) * verticalModifier, ForceMode2D.Impulse);
		}
		if (debug) {
			Debug.Log (rb.velocity);
		}

		positionChecking ();

		//Changing Stuff
		movementDirection.x = 0;
		movementDirection.y = 0;
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
