using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public AudioClip deathSound;
	public float movementModifier;
	public float verticalModifier;
	public bool canJump, moveLeft, moveRight;
	public float inputSide;
	public float BetweenJumps;
	public int jumpsLeft = 2;
	public int afterDJump = 0; 
	bool Djump_Active = false;


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
		bool debug = dev.debug;
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
		bool spaceHeldDown = Input.GetKeyDown (KeyCode.Space);
		//test = test + 0.1;
		//button held down checking stuff
		bool inputUp = Input.GetButton("Jump");
		bool inputDown = Input.GetButton("Croutch");
		inputSide = Input.GetAxis ("Horizontal");
		if (Djump_Active) {
			afterDJump++;
		}
		BetweenJumps--;
		//Needs a movement function for accurate movement, Josh pls do this
		//Check for side collision

		//code that checks for right movement
		if (inputSide > 0 && moveRight){
			transform.Translate(transform.right * movementModifier);
			moveLeft = true;
			moveRight = true;
		}

		//code that checks for left movement
		if (inputSide < 0 && moveLeft){
			transform.Translate(transform.right * movementModifier * -1);
			moveRight = true;
			moveLeft = true;
		}
		//First Jump code
		if (inputUp && canJump && noclip == false && fly == false){
			rb.AddForce(transform.up * verticalModifier * 100, ForceMode2D.Impulse);
			moveRight = true;
			moveLeft = true;
			jumpsLeft--;
			BetweenJumps = 5;
			Djump_Active = true;
		}
		//Double Jump code
		if (BetweenJumps <= 0 && jumpsLeft > 0 && spaceHeldDown == true && canJump == false) {
			rb.AddForce((transform.up * verticalModifier * 200), ForceMode2D.Impulse);
			BetweenJumps = 5;
			jumpsLeft--;
		//Rising up if noclip or fly is active
		}
		if (inputUp & (noclip || fly)) {
			transform.Translate(transform.up * .5f);
			moveRight = true;
			moveLeft = true;
		//Lowering down if noclip or fly is active
		}
		if (inputDown & (noclip || fly)) {
			transform.Translate(transform.up * -.5f);
			moveRight = true;
			moveLeft = true;
		}
		print (canJump);
		canJump = false;
	}
		//Collision detection and that stuff
		void OnCollisionStay2D (Collision2D col){
		ContactPoint2D contact = col.contacts[0]; 
		if(Vector2.Dot(contact.normal, Vector2.up) > 0.1){
			canJump = true;
			jumpsLeft = 2;
			Djump_Active = false;
			afterDJump = 0;
		}
		//if (Vector2.Dot (contact.normal, Vector2.right) > 0.1) {
			//moveLeft = false;
		//}
		//if (Vector3.Dot (contact.normal, Vector2.right) < 0) {
			//moveRight = false;
		//}
		//Code maybe to detect side collision for movement?
		
	}
}