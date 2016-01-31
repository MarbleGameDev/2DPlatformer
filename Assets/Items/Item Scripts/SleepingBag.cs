using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class SleepingBag : Iitem {
	public void Use(){
		DayCycle.hours += 1;
	}
	public void Drop(){
		
	}
    public string ToString() {
        return "Sleeping Bag";
    }
}
