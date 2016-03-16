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
		days = JsonFile.save.GameData.gameDays;
		hours = JsonFile.save.GameData.gameHours;
	}

	void TimeUpdate () { 	//Execute every second
		minutes += 0.1d;
		if (minutes >= hourLength) {
			hours++;
			minutes = 0;
			JsonFile.save.GameData.gameHours = hours;
			SaveData.queueSave = true;
		}
		if (hours >= dayLength) {
			days++;
			hours = 0;
			JsonFile.save.GameData.gameDays = days;
			SaveData.queueSave = true;
		}
	}
}
