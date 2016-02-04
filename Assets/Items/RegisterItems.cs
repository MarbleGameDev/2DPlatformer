using UnityEngine;
using System.Collections;

public class RegisterItems : MonoBehaviour {
	static bool hasRegistered = false;
	void Awake () {

		if (hasRegistered == false) {
			ItemDictionary.itemDict.Add<Diary>("Diary", new Diary ());
			ItemDictionary.itemDict.Add<Sword>("Sword",  new Sword ());
			ItemDictionary.itemDict.Add<Hands>("Hands", new Hands ());
			ItemDictionary.itemDict.Add<SleepingBag>("SleepingBag", new SleepingBag());
			ItemDictionary.itemDict.Add<Candle>("Candle", new Candle());
			ItemDictionary.itemDict.Add<BreadLoaf>("BreadLoaf", new BreadLoaf());
			ItemDictionary.itemDict.Add<Planks>("Planks", new Planks());
			ItemDictionary.itemDict.Add<Meatloaf>("Meatloaf", new Meatloaf());
			ItemDictionary.itemDict.Add<FrogLegs>("FrogLegs", new FrogLegs());
			hasRegistered = true;
		}
	}
}
