using UnityEngine;
using System.Collections;

public class CameraMovementSecobd : MonoBehaviour {

	public GameObject player;
	public float damping = 1;
	public float offsetMultiplier ;
	Vector3 offset;

	void Start() {
		offset = (player.transform.position - transform.position);
	}

	void LateUpdate() {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = player.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

		Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = player.transform.position - (rotation * offset);

		transform.LookAt(player.transform);

		DampingFactor ();
	}

	void DampingFactor()
	{
		if (Input.GetKey ("l")) {
			damping += 0.01f;
		}
		if (Input.GetKey ("o")) {
			damping -= 0.01f ;
		}

		// some sort of zooming
		if (Input.GetKey (KeyCode.Space) && offsetMultiplier < 1.4f) {
			offsetMultiplier += 0.01f;
			offset = (transform.position - player.transform.position) * offsetMultiplier;

		}

		if (Input.GetKey ("v") && offsetMultiplier > 1.0f ) {
			offsetMultiplier -= 0.01f;
			offset = (transform.position - player.transform.position) / offsetMultiplier;
		}

		//controlling how far can the zooming be
		if(offsetMultiplier<1.0f)
			offsetMultiplier = 1.0f;
		if (offsetMultiplier > 1.4f)
			offsetMultiplier = 1.4f;

	}
}
