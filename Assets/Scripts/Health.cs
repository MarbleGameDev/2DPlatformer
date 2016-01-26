using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Health : MonoBehaviour {
	public float health = 10;
    public UnityEvent hitFunction;

	void Update () {
		if (health <= 0 && !gameObject.tag.Equals("Player")) {
			DestroyObject(gameObject);
		}
	}

	public void Damage(float attack){
		health -= attack;
        hitFunction.Invoke();
	}
	public void Heal(float heal){
		health += heal;
	}
}
