using UnityEngine;
using System.Collections;

public class CameraThird : MonoBehaviour {

	public GameObject player;
	public float offsetMultiplier = 1;
	public float rotateSpeed = 5;
	Vector3 offset;

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
}
