using UnityEngine;
using System.Collections;

public class RegisterItems : MonoBehaviour {
	static bool hasRegistered = false;
	void Start () {

		if (hasRegistered == false) {
			ItemDictionary.itemDict.Add<Diary>("Diary", new Diary ());
			ItemDictionary.itemDict.Add<Sword>("Sword",  new Sword ());
			ItemDictionary.itemDict.Add<Hands>("Hands", new Hands ());
			ItemDictionary.itemDict.Add<SleepingBag>("SleepingBag", new SleepingBag());
			ItemDictionary.itemDict.Add<Candle>("Candle", new Candle());
			hasRegistered = true;
		}
	}
}
