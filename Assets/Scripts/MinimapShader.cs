using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinimapShader : MonoBehaviour {
	Camera cam;
	GameObject boarder;
	public static bool MEnabled;
	void Start(){
		cam = GetComponent<Camera> ();
		cam.SetReplacementShader (Shader.Find("Sprites/Default"), null);
		boarder = GameObject.Find("Minimap-Image");
		Input.ResetInputAxes ();

	}
	void Update(){
		if (Input.GetKey (InputManager.GetKey ("Minimap")) && !MenuManager.windowOpen) {
			if (!cam.enabled) {
				cam.enabled = true;
				boarder.SetActive(true);
				MEnabled = true;
			}
		} else {
			if (cam.enabled){
				cam.enabled = false;
				boarder.SetActive(false);
				MEnabled = false;
			}
		}
	}
}
