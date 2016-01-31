using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerPrefsSerializer {
    public static BinaryFormatter bf = new BinaryFormatter();
    // serializableObject is any struct or class marked with [Serializable]
    public static void Save(string prefKey, object serializableObject) {
        MemoryStream memoryStream = new MemoryStream();
        bf.Serialize(memoryStream, serializableObject);
        string tmp = System.Convert.ToBase64String(memoryStream.ToArray());
        PlayerPrefs.SetString(prefKey, tmp);
    }

    public static object Load(string prefKey) {
        string tmp = PlayerPrefs.GetString(prefKey, string.Empty);
        if (tmp == string.Empty)
            return null;
        MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(tmp));
        return bf.Deserialize(memoryStream);
    }
}
