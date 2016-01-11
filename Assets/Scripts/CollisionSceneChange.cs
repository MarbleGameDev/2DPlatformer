using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LevelLoad))]
public class CollisionSceneChange : MonoBehaviour {
	public string LevelName;
	public string BuildingName;
	void OnTriggerEnter2D(Collider2D col){
		SaveData.StoreData ();
		GetComponent<LevelLoad> ().LoadLevel (LevelName);
		if (BuildingName != null && !BuildingName.Equals (""))
			BuildingExitLocation.SetBuilding (BuildingName);
	}
}
