using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health = 10;

	void Update () {
		if (health <= 0) {
			DestroyObject(gameObject);
		}
	}

	public void Damage(float attack){
		Debug.Log (attack);
		health -= attack;
	}
	public void Heal(float heal){
		health += heal;
	}
}
