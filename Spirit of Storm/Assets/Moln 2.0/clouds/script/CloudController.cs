using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
	public CloudEmitter emitter;
//	private double timeSinceStarted = 0;
	public float movementSpeed = 1f;
//	public double cloudTimeToLive;
	private float rotation=0;
	public Vector3 riktningsVector;
	public float distanceToEmitter;
	bool prevfade = false;
//	private float rotationmod = 0;


//	public bool fadeOut = false;

	// Use this for initialization
	void Start () {

	}
	public void init (){
		//Denna måste tas /10 av någon anledning
		movementSpeed = emitter.cloudSpeed;
//		cloudTimeToLive = emitter.size/movementSpeed;
		riktningsVector = new Vector3(0,0,1);

	}


	
	// Update is called once per frame
	void Update () {
		movementSpeed = emitter.cloudSpeed;
//		if (prevfade != emitter.fade) {
//			if(emitter.fade == true){
//				Vector3 rvmod = (this.transform.position - emitter.transform.position +(new Vector3(0,0,200)));
//				rotationmod = Vector3.Angle(rvmod,riktningsVector)+180;
//			}
//			prevfade = emitter.fade;
//		}
		//Rotera molnet så det pekar åt emitterns direction.
		if (emitter.rotationY != rotation) {
			rotation = emitter.rotationY;
		}
		//Flytta molnet

		float rotRad = (rotation) * Mathf.Deg2Rad;
		riktningsVector = (new Vector3 (Mathf.Sin (rotRad),0,Mathf.Cos(rotRad)));
		transform.Translate(riktningsVector*movementSpeed*Time.deltaTime);


		// Tar bort
//		timeSinceStarted += Time.deltaTime;
//		if (timeSinceStarted > cloudTimeToLive) {
//			fadeOut = true;
//		}

		distanceToEmitter = Vector3.Distance (transform.position, emitter.transform.position);
		if (distanceToEmitter > emitter.size*0.71) {
			Destroy(this.gameObject);
		}
	}
	public void attachEmitter(CloudEmitter e){
		emitter = e;
	}
}
