using UnityEngine;
using System.Collections;

public class AsyncLoadScene : MonoBehaviour {
	public string SceneName;
	// Use this for initialization
	void Start () {
		Application.LoadLevelAsync (SceneName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
