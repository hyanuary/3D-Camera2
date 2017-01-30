﻿using UnityEngine;
using System.Collections;

public class CameraThird : MonoBehaviour {

	public GameObject player;
	public float offsetMultiplier = 1;
	public float rotateSpeed = 5;
	Vector3 offset;

	//zoomin variable 1
	public float curZoomPos;
	public float zoomTo;
	public float zoomFrom = 20.0f;

	//zoomin variable 2
	public float minPoint = 15.0f;
	public float maxPoint = 90.0f;
	public float sensivity = 10.0f;

	void Start() {
		offset = (player.transform.position - transform.position) * offsetMultiplier;
	}

	void LateUpdate() {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		player.transform.Rotate(0, horizontal, 0);

		float desiredAngle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = player.transform.position - (rotation * offset);

		transform.LookAt(player.transform);

		//ZoomFactor ();

		ZoomFactor2 ();

		SpeedFactor ();
	}

	void SpeedFactor()
	{
		if (Input.GetKey ("l")) {
			rotateSpeed += 0.01f;
		}
		if (Input.GetKey ("o")) {
			rotateSpeed -= 0.01f ;
		}

		// some sort of zooming
		if (Input.GetKey (KeyCode.Space))
			offsetMultiplier += 0.01f;

		if (Input.GetKey ("v"))
			offsetMultiplier -= 0.01f;

		//controlling how far can the zooming be
		if(offsetMultiplier<1)
			offsetMultiplier = 1;
		if (offsetMultiplier > 1.4f)
			offsetMultiplier = 1.4f;
	}

	void ZoomFactor()
	{
		float y = Input.mouseScrollDelta.y;

		if (y >= 1) {
			zoomTo -= 5.0f;
		} 
		else if (y >= -1) {
			zoomTo += 5.0f;
		}

		curZoomPos = zoomFrom + zoomTo;

		curZoomPos = Mathf.Clamp (curZoomPos, 5.0f, 35.0f);
		zoomTo = Mathf.Clamp (zoomTo, -15.0f, 30.0f);

		Camera.main.fieldOfView = curZoomPos;

	}

	void ZoomFactor2()
	{
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis ("Mouse ScrollWheel") * sensivity;
		fov = Mathf.Clamp (fov, minPoint, maxPoint);
		Camera.main.fieldOfView = fov;
	}
}
