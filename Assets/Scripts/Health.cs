using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 10;

	void Update () {
		if (health <= 0 && !gameObject.tag.Equals("Player")) {
			DestroyObject(gameObject);
		}
	}

	public void Damage(float attack){
		health -= attack;
	}
	public void Heal(float heal){
		health += heal;
	}
}
