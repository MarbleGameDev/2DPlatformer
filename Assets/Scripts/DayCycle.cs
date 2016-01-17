using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {
	public static int days;
	public static int hours;
	public static double minutes;

	public static int hourLength = 10;
	public static int dayLength = 24;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("TimeUpdate", 0f, 1f);
		days = SaveData.gameDays;
		hours = SaveData.gameHours;
	}

	void TimeUpdate () { 	//Execute every second
		minutes += 0.1d;
		if (minutes >= hourLength) {
			hours++;
			minutes = 0;
			SaveData.gameHours = hours;
			SaveData.StoreData();
		}
		if (hours >= dayLength) {
			days++;
			hours = 0;
			SaveData.gameDays = days;
			SaveData.StoreData();
		}
	}
}
