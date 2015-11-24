using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSliderValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UpdateSlider(){
		switch (this.gameObject.name) {
		case "OverallVolumeSlider":
			Settings.overallVolume = GetComponent<Slider>().value;
			//Debug.Log(Settings.overallVolume);
			break;
		case "MusicVolumeSlider":
			Settings.musicVolume = GetComponent<Slider>().value;
			//Debug.Log(Settings.musicVolume);
			break;
		}
	}
}
