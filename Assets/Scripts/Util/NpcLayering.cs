using UnityEngine;
using System.Collections;

public class NpcLayering : MonoBehaviour {



	GameObject player;
	SpriteRenderer sprite;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Character");
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (player.transform.position.y > gameObject.transform.position.y){
			sprite.sortingOrder = 6;
		}else{
			sprite.sortingOrder = 3;
		}
	
	}
}
