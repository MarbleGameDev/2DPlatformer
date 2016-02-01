using UnityEngine;
using System.Collections;

public interface IWeapon : IEquippable {
	float damage {
		get;
		set;
	}
	float swingSpeed {
		get;
		set;
	}
	float range {
		get;
		set;
	}
    string ID {  //ID is used to determine uniqueness for weapons
        get;    //Way to generate unique string
            //return GUID.GetUniqueID();
        set;
    }
    string Name {
        get;
        set;
    }
    float Attack();
}
