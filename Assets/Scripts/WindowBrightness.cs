using UnityEngine;
using System.Collections;

public class WindowBrightness : MonoBehaviour {
	Color window;
	SpriteRenderer windowSprite;
	float colorRate = 0.0001f;
	float nightRed = .01f;
	float dayRed = 1;
	void Start () {
		windowSprite = GetComponent<SpriteRenderer>();
		window = windowSprite.color;
	}

	void Update () {
		if (DayCycle.hours >= 18 && DayCycle.hours < 20) {
			window.r -= (window.r > nightRed) ? (colorRate) : (0);
			window.g -= (window.g > nightRed) ? (colorRate) : (0);
			window.b -= (window.b > nightRed) ? (colorRate) : (0);
		} else if (DayCycle.hours >= 6 && DayCycle.hours < 8) {
			window.r += (window.r < dayRed) ? (colorRate) : (0);
			window.g += (window.g < dayRed) ? (colorRate) : (0);
			window.b += (window.b < dayRed) ? (colorRate) : (0);
		} else if (DayCycle.hours >= 8 && DayCycle.hours < 18) {
			window.r = dayRed;
			window.g = dayRed;
			window.b = dayRed;
		} else if (DayCycle.hours >= 20 || DayCycle.hours < 6) {
			window.r = nightRed;
			window.g = nightRed;
			window.b = nightRed;
		}
		windowSprite.color = window;
	}
}
