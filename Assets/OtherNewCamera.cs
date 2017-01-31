using UnityEngine;
using System.Collections;

public class OtherNewCamera : MonoBehaviour {


	public Transform target;

	public float smoothTime = 0.1f;
	public float speed = 3.0f;

	public float followDistance = 10f;
	public float verticalBuffer = 1.5f;
	public float horizontalBuffer = 0f;

	private Vector3 velocity = Vector3.zero;

	public Quaternion rotation = Quaternion.identity;

	public float yRotation = 0.0f;

	//zoomin variable 2
	public float minPoint = 15.0f;
	public float maxPoint = 90.0f;
	public float sensivity = 10.0f;

	// How camera pitch (i.e. rotation about x axis) should vary with zoom
	public AnimationCurve pitchCurve;
	// How far the camera should be placed back along the chosen pitch based on zoom
	public AnimationCurve distanceCurve;

	// Use this for initialization
	void Start () {

		//animationCamera ();
		
	}
	
	void Update () {
		Vector3 targetPosition = target.TransformPoint(new Vector3(horizontalBuffer, followDistance, verticalBuffer));
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		//this is the code that solves the problem
		transform.eulerAngles = new Vector3(99, target.transform.eulerAngles.y, 0);

		ZoomFactor2 ();
	}

	void ZoomFactor2()
	{
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis ("Mouse ScrollWheel") * sensivity;
		fov = Mathf.Clamp (fov, minPoint, maxPoint);
		Camera.main.fieldOfView = fov;
	}

	void animationCamera ()
	{
		float zoom = Time.deltaTime;

		// Create 'S' shaped curve to adjust pitch
		// Varies from 0 (looking forward) at 0, to 90 (looking straight down) at 1
		pitchCurve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 90.0f);

		// Create exponential shaped curve to adjust distance
		// So zoom control will be more accurate at closer distances, and more coarse further away
		Keyframe[] ks = new Keyframe[2];
		// At zoom=0, offset by 0.5 units
		ks[0] = new Keyframe(0, 0.5f);
		ks[0].outTangent = 0;
		// At zoom=1, offset by 60 units
		ks[1] = new Keyframe(1, 60);
		ks[1].inTangent = 90;
		distanceCurve = new AnimationCurve(ks);

		// Calculate the appropriate pitch (x rotation) for the camera based on current zoom       
		float targetRotX = pitchCurve.Evaluate(zoom);

		// The desired yaw (y rotation) is to match that of the target object
		float targetRotY = target.rotation.eulerAngles.y;

		// Create target rotation as quaternion
		// Set z to 0 as we don't want to roll the camera
		Quaternion targetRot = Quaternion.Euler(targetRotX, targetRotY, 0.0f);

		// Calculate in world-aligned axis, how far back we want the camera to be based on current zoom
		Vector3 offset = Vector3.forward * distanceCurve.Evaluate(zoom);

		// Then subtract this offset based on the current camera rotation
		Vector3 targetPos = target.position - targetRot * offset;
	}
}