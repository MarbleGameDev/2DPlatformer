using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
	static GameObject target;
	public static bool offScreen;
	GameObject character;
	public float height, width, angle;
	// Use this for initialization
	void Start () {
		character = GameObject.Find("Character");
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			height = target.transform.position.y - character.transform.position.y;
			width = target.transform.position.x - character.transform.position.x;
			if ((height > 0 && width < 0) || (height < 0 && width > 0)) {
				angle = Mathf.Atan2(Mathf.Abs(width), Mathf.Abs(height)) * Mathf.Rad2Deg;
			} else {
				angle = Mathf.Atan2(Mathf.Abs(height), Mathf.Abs(width)) * Mathf.Rad2Deg;
			}
			float angleToTarget = angle;
			if (height <= 0 && width <= 0)
				angleToTarget += 180;
			else if (height < 0 && width >= 0)
				angleToTarget += 270;
			else if (height > 0 && width < 0)
				angleToTarget += 90;
			transform.localEulerAngles = new Vector3(0, 0, angleToTarget);
		}
	}

	public static void SetObj(GameObject obj) {
		target = obj;
	}
}
