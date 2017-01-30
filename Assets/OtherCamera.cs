using UnityEngine;
using System.Collections;

public class OtherCamera : MonoBehaviour {

	public AnimationCurve zoomMode;
	public float zoomSpeed;
	public float zoomTime; 
	public float damping = 1000;
	Vector3 offset;

	public GameObject player;
	// Use this for initialization
	void Start () {
		
		offset = transform.position - player.transform.position;
	}

	
	// Update is called once per frame
	void Update () {
		//float distance = Vector3.Distance (player.transform.position, transform.position);
		OpenOut ();
	}

	public void OpenOut()
	{
		StartCoroutine (_zoomIn());
	}

	IEnumerator _zoomIn() 
	{
		float curveTime = 0f;
		float curveAmount = zoomMode.Evaluate (curveTime);

		while (curveAmount < 1.0f && Input.GetKeyUp("w") || Input.GetKeyUp("d")  || Input.GetKeyUp("a") || Input.GetKeyUp("s"))
		{
			curveTime = Time.deltaTime * zoomSpeed;
			curveAmount = zoomMode.Evaluate (curveTime);

			//1st type
			Vector3 desiredPosition = player.transform.position + offset;
			Vector3 position = Vector3.Lerp(transform.position, desiredPosition , Time.deltaTime * damping);
			transform.position = position;
			transform.LookAt(player.transform.position);

			//second type
			//transform.position = Vector3.MoveTowards (transform.position, player.transform.position + offset, damping * Time.deltaTime);
			yield return null;
		}
	}

}
