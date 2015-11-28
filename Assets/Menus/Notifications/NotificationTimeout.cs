using UnityEngine;
using System.Collections;

public class NotificationTimeout : MonoBehaviour {
	public float timer = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			transform.position = new Vector2 (transform.position.x, transform.position.y + 2);
		}
		if (transform.localPosition.y > 80) {
			Destroy (gameObject);
		}
	}
}
