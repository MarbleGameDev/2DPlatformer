using UnityEngine;
using System.Collections;

public class RightCharacterCollider : MonoBehaviour {
	CharacterMovement charMove;
	// Use this for initialization
	void Start () {
		charMove = GameObject.Find ("character").GetComponent<CharacterMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D (Collision2D col){
		charMove.collisionRight = true;
	}
}
