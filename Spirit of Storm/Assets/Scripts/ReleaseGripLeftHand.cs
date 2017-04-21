using UnityEngine;
using System.Collections;

public class ReleaseGripLeftHand : MonoBehaviour {

	public float closeHandDuration = 0.2f;
	public float openHandDuration = 0.2f;
	public float closeThumbDuration = 0.3f;
	public float openThumbDuration = 0.2f;

	public Transform fingers;
	public Transform indexFinger;
	public Transform middleFinger;
	public Transform ringFinger;
	public Transform littleFinger;
	public Transform thumb;
	public Transform thumb2;

	private InteractionManager manager;

	private Vector3 fingersOpen = new Vector3 (0,0,0);
	private Vector3 fingersClosedPos = new Vector3 (-0.1908883f, -0.2438034f, 0.0006796952f);
	private Vector3 fingersClosedRot = new Vector3 (0,0,-78.073f);

	private Vector3 indexFingerOpenPos;
	private Vector3 indexFingerOpenRot;
	private Vector3 indexFingerClosedPos = new Vector3 (-0.1121446f, -2.008795e-05f, -7.417682e-05f);
	private Vector3 indexFingerClosedRot = new Vector3 (0.0457f, 2.0202f, 263.353f);

	private Vector3 middleFingerOpenPos;
	private Vector3 middleFingerOpenRot;
	private Vector3 middleFingerClosedPos = new Vector3 (-0.1699797f, -0.02002009f, -0.01004376f);
	private Vector3 middleFingerClosedRot = new Vector3 (359.924f, 0.5709f, 260.791f);

	private Vector3 ringFingerOpenPos;
	private Vector3 ringFingerOpenRot;
	private Vector3 ringFingerClosedPos = new Vector3 (-0.11678f, 0.0f, 0.0f);
	private Vector3 ringFingerClosedRot = new Vector3 (0.6068f, 354.598f, 250.579f);

	private Vector3 littleFingerOpenPos;
	private Vector3 littleFingerOpenRot;
	private Vector3 littleFingerClosedPos = new Vector3 (-0.09641778f, 0.0f, 0.0f);
	private Vector3 littleFingerClosedRot = new Vector3 (0.5677f, 355.435f, 260.991f);

	private Vector3 thumbOpenPos;
	private Vector3 thumbOpenRot;
	private Vector3 thumbClosedPos = new Vector3 (-0.05478029f, 0.0f, 0.0f);
	private Vector3 thumbClosedRot = new Vector3 (25.4828f, 18.0988f, 314.690f);

	private Vector3 thumb2OpenPos;
	private Vector3 thumb2OpenRot;
	private Vector3 thumb2ClosedPos = new Vector3 (-0.09498617f, 0.0f, 0.0f);
	private Vector3 thumb2ClosedRot = new Vector3 (354.817f, 352.548f, 295.744f);

	private bool opened = true;
	private bool grip = false;
	private bool closed = false;
	private bool open = false;
	private float startTime;

	void Start () {
		indexFingerOpenPos = indexFinger.localPosition;
		indexFingerOpenRot = indexFinger.localRotation.eulerAngles;

		middleFingerOpenPos = middleFinger.localPosition;
		middleFingerOpenRot = middleFinger.localRotation.eulerAngles;

		ringFingerOpenPos = ringFinger.localPosition;
		ringFingerOpenRot = ringFinger.localRotation.eulerAngles;

		littleFingerOpenPos = littleFinger.localPosition;
		littleFingerOpenRot = littleFinger.localRotation.eulerAngles;

		thumbOpenPos = thumb.localPosition;
		thumbOpenRot = thumb.localRotation.eulerAngles;
		thumb2OpenPos = thumb2.localPosition;
		thumb2OpenRot = thumb2.localRotation.eulerAngles;
	}
		
	void Update () {

		if (manager == null) {
			manager = InteractionManager.Instance;
		}

		if (manager.GetLastLeftHandEvent () == InteractionManager.HandEventType.Grip) {
			if (opened) {
				opened = false;
				open = false;
				grip = true;
				print (grip);
				startTime = Time.time;
			}
		} 
		else if (manager.GetLastLeftHandEvent () == InteractionManager.HandEventType.Release) {
			if (closed) {
				closed = false;
				grip = false;
				open = true;
				startTime = Time.time;
			}
		}

		if (grip) {
			float t = (Time.time - startTime) / closeHandDuration;
			float t2 = (Time.time - startTime) / closeThumbDuration;

			fingers.localRotation = Quaternion.Euler (Vector3.Lerp (fingersOpen, fingersClosedRot, t));
			fingers.localPosition = Vector3.Lerp (fingersOpen, fingersClosedPos, t);

			indexFinger.localRotation = Quaternion.Euler (Vector3.Lerp (indexFingerOpenRot, indexFingerClosedRot, t));
			indexFinger.localPosition = Vector3.Lerp (indexFingerOpenPos, indexFingerClosedPos, t);

			middleFinger.localRotation = Quaternion.Euler (Vector3.Lerp (middleFingerOpenRot, middleFingerClosedRot, t));
			middleFinger.localPosition = Vector3.Lerp (middleFingerOpenPos, indexFingerClosedPos, t);

			ringFinger.localRotation = Quaternion.Euler (Vector3.Lerp (ringFingerOpenRot, ringFingerClosedRot, t));
			ringFinger.localPosition = Vector3.Lerp (ringFingerOpenPos, ringFingerClosedPos, t);

			littleFinger.localRotation = Quaternion.Euler (Vector3.Lerp (littleFingerOpenRot, littleFingerClosedRot, t));
			littleFinger.localPosition = Vector3.Lerp (littleFingerOpenPos, littleFingerClosedPos, t);

			thumb.localRotation = Quaternion.Euler (Vector3.Lerp (thumbOpenRot, thumbClosedRot, t));
			thumb.localPosition = Vector3.Lerp (thumbOpenPos, thumbClosedPos, t);
			thumb2.localRotation = Quaternion.Euler (Vector3.Lerp (thumb2OpenRot, thumb2ClosedRot, t2));
			thumb2.localPosition = Vector3.Lerp (thumb2OpenPos, thumb2ClosedPos, t2);
			if (t >= 1 && t2 >= 1) {
				closed = true;
			}
		} 
		else if (open) {
			float t = (Time.time - startTime) / openHandDuration;
			float t2 = (Time.time - startTime) / openThumbDuration;

			fingers.localRotation = Quaternion.Euler (Vector3.Lerp (fingersClosedRot, fingersOpen, t));
			fingers.localPosition = Vector3.Lerp (fingersClosedPos, fingersOpen, t);

			indexFinger.localRotation = Quaternion.Euler (Vector3.Lerp (indexFingerClosedRot, indexFingerOpenRot, t));
			indexFinger.localPosition = Vector3.Lerp (indexFingerClosedPos, indexFingerOpenPos, t);

			middleFinger.localRotation = Quaternion.Euler (Vector3.Lerp (middleFingerClosedRot, middleFingerOpenRot, t));
			middleFinger.localPosition = Vector3.Lerp (indexFingerClosedPos, middleFingerOpenPos, t);

			ringFinger.localRotation = Quaternion.Euler (Vector3.Lerp (ringFingerClosedRot, ringFingerOpenRot, t));
			ringFinger.localPosition = Vector3.Lerp (ringFingerClosedPos, ringFingerOpenPos, t);

			littleFinger.localRotation = Quaternion.Euler (Vector3.Lerp (littleFingerClosedRot, littleFingerOpenRot, t));
			littleFinger.localPosition = Vector3.Lerp (littleFingerClosedPos, littleFingerOpenPos, t);

			thumb.localRotation = Quaternion.Euler (Vector3.Lerp (thumbClosedRot, thumbOpenRot, t2));
			thumb.localPosition = Vector3.Lerp (thumbClosedPos, thumbOpenPos, t2);
			thumb2.localRotation = Quaternion.Euler (Vector3.Lerp (thumb2ClosedRot, thumb2OpenRot, t2));
			thumb2.localPosition = Vector3.Lerp (thumb2ClosedPos, thumb2OpenPos, t2);
			if (t >= 1 && t2 >= 1) {
				opened = true;
			}
		}	
	}
}
