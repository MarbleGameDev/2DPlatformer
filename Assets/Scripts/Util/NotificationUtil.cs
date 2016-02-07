using UnityEngine;
using System.Collections;

public class NotificationUtil : MonoBehaviour {
	public string notificationTop;
	public string notificationBottom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateNotification(){

		NotificationManager.AddNotification (notificationTop, notificationBottom);

	}

}
