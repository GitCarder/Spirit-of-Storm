using UnityEngine;
using System.Collections;

public class WeatherManager : MonoBehaviour {

	public GameObject uniStormSystem;
	public GameObject cloudEmitter;

	private CloudEmitter ce;
	private float speedMod = 5;
	private float emissionMod = 2;

	public AudioClip swipe;
	AudioSource radio;

	void Start () {
		ce = cloudEmitter.GetComponent<CloudEmitter> ();
		radio = GetComponent<AudioSource> ();
	}

	public void changeWeather(int mode) {
		uniStormSystem.GetComponent<UniStormWeatherSystem_C>().weatherForecaster = mode;

		// STORM
		if (mode == 3) {
			ce.fade = false;

			ce.colorR = 100;
			ce.colorG = 100;
			ce.colorB = 100;

			ce.emissionRate = 4 * emissionMod;
			ce.cloudSpeed = 4 * speedMod;
		} 
		// SNOW
		else if (mode == 2) {
			ce.fade = false;

			ce.colorR = 150;
			ce.colorG = 150;
			ce.colorB = 150;

			ce.emissionRate = 4 * emissionMod;
			ce.cloudSpeed = 4 * speedMod;
		}
		// RAIN
		else if (mode == 12) {
			ce.fade = false;

			ce.colorR = 155;
			ce.colorG = 155;
			ce.colorB = 155;

			ce.emissionRate = 4 * emissionMod;
			ce.cloudSpeed = 4 * speedMod;
		}
		// SUNSHINE
		else if (mode == 10) {
			ce.fade = true;

			ce.colorR = 255;
			ce.colorG = 255;
			ce.colorB = 255;
			
			ce.cloudSpeed = 40 * speedMod;
		}
	}

	public void rightGestCloud() {
		print ("Right");
		radio.PlayOneShot(swipe, 0.2f);
		if (ce.rotationY == 90 && ce.cloudSpeed < 6 * speedMod) {
			ce.cloudSpeed = ce.cloudSpeed + speedMod;
		} else {
			if (ce.cloudSpeed > 2 * speedMod) {
				ce.cloudSpeed = ce.cloudSpeed / speedMod;
			} else {
				ce.rotationY = 90;
			}
		}
	}

	public void leftGestCloud() {
		print ("Left");
		radio.PlayOneShot(swipe, 0.2f);
		if (ce.rotationY == 270 && ce.cloudSpeed < 6 * speedMod) {
			ce.cloudSpeed = ce.cloudSpeed + speedMod;
		} else {
			if (ce.cloudSpeed > 2 * speedMod) {
				ce.cloudSpeed = ce.cloudSpeed / speedMod;
			} else {
				ce.rotationY = 270;
			}			
		}
	}
}