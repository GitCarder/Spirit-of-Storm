using UnityEngine;
using System.Collections;

public class CloudColor : MonoBehaviour {
	private Color prevColor = Color.white;
	private Color newColor;
	private Color realColor;
//	private float changeTime = 1f;
	private float lerpT;
//	private float lerpA;
	private int changeSteps;
	private bool locked = false;

	public CloudEmitter emitter;
	public CloudController controller;

	public bool prevFade;
	private bool fadeLock = false;
	private float fadeLerp;

	private float fadetime;

	// Use this for initialization
	void Start () {
		emitter = controller.emitter;
		int offset = Random.Range(-20, 20);
		prevColor = new Color ((emitter.colorR + offset) / 256, (emitter.colorG + offset) / 256, (emitter.colorB + offset) / 256, GetComponent<Renderer>().material.color.a);
		//prevColor = new Color (emitter.colorR / 256, emitter.colorG / 256, emitter.colorB / 256,1/256);
		GetComponent<Renderer>().material.EnableKeyword ("_EMISSION");
		GetComponent<Renderer>().material.SetColor ("_EmissionColor", prevColor);
		GetComponent<Renderer>().material.SetColor ("_Color", prevColor);
		prevFade = true;
		fadetime = 4;
		
		//fadelerp är -1 när inget ska fadea
		fadeLerp = -1;
		if (emitter.fade) {
			Color temp = GetComponent<Renderer> ().material.color;
			temp.a = 0.01f;
			GetComponent<Renderer> ().material.SetColor ("_EmissionColor", temp);
			GetComponent<Renderer> ().material.SetColor ("_Color", temp);
		} else {
//			Destroy(this.gameObject.transform.parent.transform.parent.transform.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if(emitter.fade != 0&&!fadeLock){
//			lerpA = 0;
//			fadeLock=true;
//		}
//		if (fadeLock) {
//			if(lerpA<1){
//			Color temp = GetComponent<Renderer>().material.color;
//			temp.a = (emitter.fade==1) ? Mathf.Lerp(0,1,lerpA) : Mathf.Lerp(1,0,lerpA);
//			GetComponent<Renderer>().material.color = temp;
//			lerpA += .05F;
//			print (lerpA);
//			}else{
//				Color temp = GetComponent<Renderer>().material.color;
//				temp.a = (emitter.fade==1) ? 1 : 0;
//				GetComponent<Renderer>().material.color = temp;
//				fadeLock=false;
////			}
//		}
		if(emitter.fade!=prevFade && !fadeLock){
			fadeLerp = 0F;
			fadeLock = true;
		}	
		if (fadeLock) {
			//om den var icke fadead
			if (fadeLerp != -1f) {
				fadeLerp += Time.deltaTime/fadetime;
				Color temp = GetComponent<Renderer> ().material.color;
				temp.a = (!prevFade) ? Mathf.Lerp (1, 0, fadeLerp) : Mathf.Lerp (0, 1, fadeLerp);
				GetComponent<Renderer> ().material.SetColor ("_EmissionColor", temp);
				GetComponent<Renderer> ().material.SetColor ("_Color", temp);
				if (fadeLerp >= 1) {
					if (prevFade) {
						fadeLerp = -1f;
						prevFade = !prevFade;
						fadeLock = false;
						// If it faded off destroy prefab.

					} else {
//						Destroy(this.gameObject.transform.parent.transform.parent.transform.gameObject);
					}
				}
			}
		}
//			Destroy(this.gameObject.transform.parent.transform.parent.transform.gameObject);


//			Color temp = GetComponent<Renderer>().material.color;
//			temp.a = 0f;
//			GetComponent<Renderer>().material.SetColor ("_EmissionColor", temp);
//			GetComponent<Renderer>().material.SetColor ("_Color", temp);




		if (!locked) {
			if (prevColor.r != emitter.colorR / 256 || prevColor.b != emitter.colorB / 256 || prevColor.g != emitter.colorG / 256) {
				locked = true;
				int offset = Random.Range(-30, 30);
				realColor = new Color (emitter.colorR / 256, emitter.colorG / 256, emitter.colorB  / 256, GetComponent<Renderer>().material.color.a);
				newColor = new Color ((emitter.colorR + offset) / 256, (emitter.colorG + offset) / 256, (emitter.colorB + offset) / 256, GetComponent<Renderer>().material.color.a);
				lerpT = 0;
			}


		}


		if (locked) {
			if (lerpT < 1) {
				float alpha = GetComponent<Renderer> ().material.color.a;
				Color c = Color.Lerp (prevColor, newColor, lerpT);
				GetComponent<Renderer>().material.SetColor ("_EmissionColor", c);
				GetComponent<Renderer>().material.SetColor ("_Color", c);

				lerpT += 0.01f;
			} else {
				GetComponent<Renderer>().material.SetColor ("_EmissionColor", newColor);
				GetComponent<Renderer>().material.SetColor ("_Color", newColor);
				prevColor = realColor;
				locked = false;
			}
		}

	}


//	public void changeColor(float r, float g, float b){
//		r = r / 256;
//		g = g / 256;
//		b = b / 256;
//		if(!locked){
//			if(r!=prevColor.r||g!=prevColor.g||b!=prevColor.b){
//				newColor = new Color(r,g,b);
//				locked = true;
//				lerpT = 0;
//			}
//		}
//	}
//	public void forceColor(float r, float g, float b){
//		r = r / 256;
//		g = g / 256;
//		b = b / 256;
//
//		newColor = new Color(r,g,b);
//		prevColor = newColor;
//	
//	}


 
}