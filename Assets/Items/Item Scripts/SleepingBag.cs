using UnityEngine;
using System.Collections;

public class SleepingBag : Iitem {
	public void Use(){
		DayCycle.hours += 1;
	}
	public void Drop(){
		
	}
	public void Equip(){}
	public float Attack(){
		return 0f;
	}
}
