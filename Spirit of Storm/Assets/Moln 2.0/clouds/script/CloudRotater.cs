using UnityEngine;
using System.Collections;

public class CloudRotater : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Rotate(0,Random.Range(0,359),0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
