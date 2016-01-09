using UnityEngine;
using System.Collections;

public class MinimapShader : MonoBehaviour {
	Camera cam;
	void Start(){
		 cam = GetComponent<Camera> ();
		cam.SetReplacementShader (Shader.Find("Sprites/Default"), null);

	}
	void Update(){
		if (Input.GetKey (InputManager.GetKey ("Minimap"))) {
			if (!cam.enabled) {
				cam.enabled = true;
			}
		} else {
			if (cam.enabled){
				cam.enabled = false;
			}
		}
	}
}
