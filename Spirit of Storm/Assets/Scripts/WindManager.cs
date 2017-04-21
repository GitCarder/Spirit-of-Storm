using UnityEngine;
using System.Collections;

public class WindManager : MonoBehaviour {

	public GameObject cloud;

	private float windSpeed = 0.0f;
	private Vector3 direction;
	private bool incrSpeed = false;
	private bool decrSpeed = false;
	private int changeSpeed = 5;

	void Start () {
		float x = Random.value;
		if (Random.value > 0.5)
			x = -x;

		float y = Random.value;
		if (Random.value > 0.5)
			y = -y;
		direction = Vector3.Normalize (new Vector3 (x, y, 0));
	}

	void Update () {

		if (incrSpeed) {
			incrSpeed = false;
			windSpeed += changeSpeed;
		} else if (decrSpeed) {
			decrSpeed = false;
			windSpeed -= changeSpeed;
		}
		transform.Translate (direction * windSpeed *  Time.deltaTime);
	}

	public void IncreaseSpeed () {
		incrSpeed = true;
	}

	public void DecreaseSpeed () {
		decrSpeed = true;
	}
}
