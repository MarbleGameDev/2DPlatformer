using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {
	public static int days = SaveData.gameDays;
	public static int hours = SaveData.gameHours;
	public static double minutes = SaveData.gameMinutes;

	public static int hourLength = 10;
	public static int dayLength = 24;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("TimeUpdate", 0f, 1f);
	}

	void TimeUpdate () { 	//Execute every second
		minutes += 0.1d;
		if (minutes >= hourLength) {
			hours++;
			minutes = 0;
		}
		if (hours >= dayLength) {
			days++;
			hours = 0;
		}
		Debug.Log ("minutes: " + minutes + " hours: " + hours);
	}
}
