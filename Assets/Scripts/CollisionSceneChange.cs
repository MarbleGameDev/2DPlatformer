using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LevelLoad))]
public class CollisionSceneChange : MonoBehaviour {
	public int depth;
	void OnTriggerEnter(Collider col){
		GetComponent<LevelLoad> ().LoadLevel (depth);
	}
}
