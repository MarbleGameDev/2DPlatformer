using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class SleepingBag : Iitem {
    string description = "Sleep through the night";

    public string Description {
        get {
            return description;
        }
        set {
            description = value;
        }
    }
    public void Use(){
		DayCycle.hours += 1;
	}
	public void Drop(){
		
	}
    public override string ToString() {
        return "Sleeping Bag";
    }
    public string[] DisplayInformation() {
        string[] description = new string[1];
        description[0] = this.description;
        return description;
    }
}
