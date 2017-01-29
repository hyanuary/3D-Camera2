using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	public float damping = 1;
	public float offsetMultiplier;
	Vector3 offset;


	void Start() {
		
		offset = (transform.position - player.transform.position);
	}

	void LateUpdate() {
		
		Vector3 desiredPosition = player.transform.position + offset;
		Vector3 position = Vector3.Lerp(transform.position, desiredPosition , Time.deltaTime * damping);
		transform.position = position;

		transform.LookAt(player.transform.position);

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
