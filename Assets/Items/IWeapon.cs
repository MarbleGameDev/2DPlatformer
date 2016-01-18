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
	float Attack();
}
