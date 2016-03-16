using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

public class JsonFile : MonoBehaviour {
	static string saveFilePath = "/SaveData.json";
	public static Save save;
	// Use this for initialization
	void Awake () {
		save = new Save();
		if (!File.Exists(Application.dataPath + saveFilePath)) {
			WriteData();
		} else {
			ReadData();
		}
	}

	public static void WriteData() {
		string output = JsonConvert.SerializeObject(save, Formatting.Indented);
		File.WriteAllText(Application.dataPath + saveFilePath, output);

		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
		#endif
	}
	public static void ReadData() {
		string jsonString;
		jsonString = File.ReadAllText(Application.dataPath + "/SaveData.json");
		save = JsonConvert.DeserializeObject<Save>(jsonString);
		Debug.Log(save.PlayerData.EquippedItem);
	}
}
