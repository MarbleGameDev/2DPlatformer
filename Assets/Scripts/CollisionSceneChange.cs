using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LevelLoad))]
public class CollisionSceneChange : MonoBehaviour {
	[Header("(Multiplied by 20 for y-level)")]
	public int depth;
	void OnTriggerEnter(Collider col){
		GetComponent<LevelLoad> ().LoadLevel (depth);
	}
}
