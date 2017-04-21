using UnityEngine;
using System.Collections;

public class GrabAndShineRight : MonoBehaviour 
{
	public GameObject[] clouds;
	public GameObject[] rightFlares;
	public int[] weatherParam;
	public Transform cam;
	
	public AudioClip grab;
	public AudioClip[] release;
	
	AudioSource radio;
	
	private int weather = -1;
	private WeatherManager wm;
	private InteractionManager manager;
	
	void Start () {
		deactivateFlare ();
		wm = cam.GetComponent<WeatherManager>();
		radio = GetComponent<AudioSource> ();
	}
	
	void Update() {
		if(manager == null)
		{
			manager = InteractionManager.Instance;
		}
		
		if(manager != null && manager.IsInteractionInited())
		{

			// if the left hand is primary, check for left hand grip
			if(manager.GetLastRightHandEvent() == InteractionManager.HandEventType.Release)
			{
				deactivateFlare();
				if(weather >= 0 && weather < weatherParam.Length) {
					wm.changeWeather(weatherParam[weather]);
					radio.PlayOneShot(release[weather], 0.2f);
				}
				weather = -1;
			}	
		}			
	}
	
	void OnTriggerStay(Collider col) 
	{
		for (int i = 0; i < clouds.Length; i++) {
			if (col.gameObject == clouds[i]) {
				changeWeather (i);
				break;
			}
		}
	}
	
	void changeWeather(int mode) {
		if(manager == null)
		{
			manager = InteractionManager.Instance;
		}
		
		if(manager != null && manager.IsInteractionInited())
		{

			// if the right hand is primary, check for right hand grip
			if(manager.GetLastRightHandEvent() == InteractionManager.HandEventType.Grip)
			{
				if (weather != mode) {
					radio.PlayOneShot(grab, 0.2f);
					deactivateAllFlaresExcept(mode);
					rightFlares[mode].SetActive(true);
					weather = mode;								
				}
			}
		}
	}
	
	void deactivateFlare() {
		foreach (GameObject rflare in rightFlares) {
			rflare.SetActive(false);
		}
	}

	void deactivateAllFlaresExcept(int flare){
		for (int i = 0; i < rightFlares.Length; i++) {
			if(flare != i)
				rightFlares[i].SetActive(false);
		}
	}
}

