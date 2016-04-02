using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
	static GameObject target;
	public static bool offScreen;
	GameObject character;
	public float height, width, angle;
	// Use this for initialization
	void Start () {
		character = GameObject.Find("Character");	//Locates the main character
	}
	
	void Update () {
		if (target != null) {
			height = target.transform.position.y - character.transform.position.y;
			width = target.transform.position.x - character.transform.position.x;	//Trig
			if ((height > 0 && width < 0) || (height < 0 && width > 0)) {	//Use correct lengths for arctan functions
				angle = Mathf.Atan2(Mathf.Abs(width), Mathf.Abs(height)) * Mathf.Rad2Deg;
			} else {
				angle = Mathf.Atan2(Mathf.Abs(height), Mathf.Abs(width)) * Mathf.Rad2Deg;
			}
			float angleToTarget = angle;
			if (height <= 0 && width <= 0)	//Modify the angle depending on the quadrant of the unit circle
				angleToTarget += 180;
			else if (height < 0 && width >= 0)
				angleToTarget += 270;
			else if (height > 0 && width < 0)
				angleToTarget += 90;
			transform.localEulerAngles = new Vector3(0, 0, angleToTarget);	//Set the local rotation in angle around the z axis
		}
	}
	/// <summary>
	/// Sets the gameobject to be used as the current target location
	/// </summary>
	/// <param name="obj"></param>
	public static void SetObj(GameObject obj) {
		target = obj;
	}
}
