using UnityEngine;
using System.Collections;

public interface Iitem{
	int Cost {
		get;
		set;
	}
	void Use();
	void Drop();
    string Description {
        get;
        set;
    }
    string ToString();  //Must be the same of each object for them to stack
    string[] DisplayInformation();  //Length of 1 for items, length of 4 for weapons
}
