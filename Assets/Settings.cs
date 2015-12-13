using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour { 	//Still need to work on writing changes to disk with PlayerPrefs
	public static bool fullscreen = false;

	public static float overallVolume;
	public static float musicVolume;

	public static bool debug = true;
	public static bool noclip = false;

	public static int saveInterval = 5;
}
