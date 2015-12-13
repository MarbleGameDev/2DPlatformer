using UnityEngine;
using System.Collections;

public class CollisionSceneChange : MonoBehaviour {
	public string levelName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		SaveData.StoreData ();
		Application.LoadLevelAsync (levelName);
	}
}
