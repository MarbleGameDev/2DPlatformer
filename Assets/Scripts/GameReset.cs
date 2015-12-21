using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {
	public static bool reset;
	// Use this for initialization
	void Start () {
		if (reset) {
			SaveData.ResetInvData();
			SaveData.ResetQuestData();
			reset = false;
			Debug.Log("Game Reset");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetReset(){
		reset = true;
	}
}
