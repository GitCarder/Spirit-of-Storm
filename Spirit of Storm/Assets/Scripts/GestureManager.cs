using UnityEngine;
using System.Collections;

public class GestureManager : MonoBehaviour {

	private GestureListenerGod gestureListener;
	private WeatherManager wm;

	void Start () {
		wm = this.gameObject.GetComponent<WeatherManager>();
		gestureListener = this.gameObject.GetComponent<GestureListenerGod>();
	}

	void Update () {
		KinectManager kinectManager = KinectManager.Instance;
		if((!kinectManager || !kinectManager.IsInitialized() || !kinectManager.IsUserDetected()))
			return;

		if (gestureListener.IsSwipeLeft ())
			wm.leftGestCloud ();
		else if (gestureListener.IsSwipeRight ())
			wm.rightGestCloud ();
	}
}
