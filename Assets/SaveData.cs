using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData : MonoBehaviour {

	public static MemoryStream memoryStream = new MemoryStream();
	public static BinaryFormatter bf = new BinaryFormatter();

	public delegate void resetData();
	public static event resetData ResetInv = null;
	public static bool queueSave;

	// Use this for initialization
	void Awake () {
		InventoryData.Awake();
	}

	public static void ResetInvData(){
		if (ResetInv != null) {
			ResetInv ();
		}
		JsonFile.WriteData();
	}
	public static void ResetQuestData(){
        QuestDictionary.Reset();
		JsonFile.WriteData();
	}
    public static void ResetEverything() {
		JsonFile.save = new Save();
		JsonFile.WriteData();
    }

	void Start(){
		InvokeRepeating ("Store", 10f, (float)(Settings.saveInterval * 60));
		InvokeRepeating("Store1", 4f, 4f);
	}

	void Store(){
		JsonFile.WriteData();
	}
	void Store1() {
		if (queueSave) {
			JsonFile.WriteData();
			queueSave = false;
		}
	}

	public static string SerializeObject(object serializableObject) {
		memoryStream = new MemoryStream();
		bf.Serialize(memoryStream, serializableObject);
		string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
		return tmp;
	}
	public static object DeSerializeObject(string key) {
		if (key == string.Empty)
			return null;
		memoryStream = new MemoryStream(System.Convert.FromBase64String(key));
		return bf.Deserialize(memoryStream);
	}
}
