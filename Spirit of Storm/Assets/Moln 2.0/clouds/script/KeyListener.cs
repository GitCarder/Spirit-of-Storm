using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {
	public CloudEmitter emitter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			float gray = Random.Range(0f,255f);
			emitter.colorR = gray;
			emitter.colorG = gray;
			emitter.colorB = gray;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			emitter.rotationY += 1;
			emitter.rotationY = emitter.rotationY%360;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			emitter.rotationY -= 1;
			emitter.rotationY = (emitter.rotationY+360)%360;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			emitter.cloudSpeed += emitter.cloudSpeed*0.02f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			emitter.cloudSpeed -= emitter.cloudSpeed*0.02f;
		}
	}
}
