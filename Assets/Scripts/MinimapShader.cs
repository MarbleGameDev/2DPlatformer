using UnityEngine;
using System.Collections;

public class MinimapShader : MonoBehaviour {
	Camera cam;
	GameObject boarder;
	void Start(){
		cam = GetComponent<Camera> ();
		cam.SetReplacementShader (Shader.Find("Sprites/Default"), null);
		boarder = GameObject.Find("Minimap-Image");

	}
	void Update(){
		if (Input.GetKey (InputManager.GetKey ("Minimap")) && !MenuManager.windowOpen) {
			if (!cam.enabled) {
				cam.enabled = true;
				boarder.SetActive(true);
			}
		} else {
			if (cam.enabled){
				cam.enabled = false;
				boarder.SetActive(false);
			}
		}
	}
}
