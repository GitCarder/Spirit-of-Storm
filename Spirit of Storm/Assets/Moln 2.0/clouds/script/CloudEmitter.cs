using UnityEngine;
using System.Collections;

public class CloudEmitter : MonoBehaviour {
	public float timeSinceDrawn = 0;
	public float emissionRate = 10f;

	public float height = 20f;
	public float rotationY = 0f;
	public float size = 100;
	public float cloudSpeed;

//	private float prevR = 255f;
//	private float prevG = 255f;
//	private float prevB = 255f;
	private float width;
	public float colorR;
	public float colorG;
	public float colorB;
	private Vector3 position;
	
	public bool fade = false;



	// Use this for initialization
	void Start () {

		width = size/2; 
		fillSky ();

	}

	// Update is called once per frame
	void Update () {
		timeSinceDrawn += Time.deltaTime;



		if (timeSinceDrawn > 1/emissionRate &&!fade) {
			timeSinceDrawn = 0;


			GameObject moln = (GameObject)Instantiate(Resources.Load("moln"));

			position = transform.position;
				moln.transform.position = Quaternion.Euler(0, rotationY, 0) * (new Vector3(Random.Range(-width, width), Random.Range(-height, height), Random.Range(-5.0F, 5.0F)-size/2))+position;
			moln.GetComponent<CloudController>().attachEmitter(this);
			moln.GetComponent<CloudController>().init();

			// kollat om färgen har ändrats och ändrar i så fall molnen

//			if(prevR != colorR || prevB != colorB || prevG != colorG ){
//				GameObject[] clouds = GameObject.FindGameObjectsWithTag ("cloud");
//				foreach(GameObject go in clouds){
//					go.GetComponent<CloudColor>().changeColor(colorR,colorG,colorB);
//				}
//
//				prevR = colorR;
//				prevB = colorB;
//				prevG = colorG;
//			}
		}


	}

	private void fillSky(){
		int clouds = (int) (size/cloudSpeed * emissionRate);
		int stepwidth = (int) size/clouds;
		for (int i =0; i<clouds; i++) {
			position = transform.position;
			
			
			GameObject moln = (GameObject)Instantiate(Resources.Load("moln"));
			moln.transform.position = Quaternion.Euler(0, rotationY, 0) * (new Vector3(Random.Range(-width, width), Random.Range(-height, height), Random.Range(-5.0F, 5.0F)-size/2)+ new Vector3 (0,0,i*stepwidth)) +position; 
			
			
			moln.GetComponent<CloudController>().attachEmitter(this);
			moln.GetComponent<CloudController>().init();
		}
	}
}
