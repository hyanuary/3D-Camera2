using UnityEngine;
using System.Collections;

public class OtherCamera : MonoBehaviour {

	//animation curve variables 
	public AnimationCurve zoomMode;
	public float zoomSpeed;
	public float zoomTime; 
	public float damping = 1000;
	Vector3 offset;

	//lerping part
	private Vector3 startPos;
	private Vector3 currPos;
	private float distance = 2f;
	public float lerpTime = 5;
	public float currLerpTime = 0;
	public bool keyHit = false;

	public GameObject player;
	// Use this for initialization
	void Start () {
		
		offset = transform.position - player.transform.position;
		startPos = transform.position;
	}

	
	// Update is called once per frame
	void Update () {
		//float distance = Vector3.Distance (player.transform.position, transform.position);
		OpenOut ();

		//Type1 ();

		Type2 ();

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
			curveTime += Time.deltaTime * zoomSpeed;
			curveAmount = zoomMode.Evaluate (curveTime);

			//1st type
			/*Vector3 desiredPosition = (player.transform.position + offset);
			Vector3 position = Vector3.Lerp(transform.position, desiredPosition , Time.deltaTime * damping);
			transform.position = position *  curveAmount;
			transform.LookAt(player.transform.position);*/

			//second type
			//transform.position = Vector3.MoveTowards (transform.position, player.transform.position + offset, damping * curveAmount );
			yield return null;


		}
	}

	void Type1()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			keyHit = true;

		if (keyHit == true) {
			currLerpTime += Time.deltaTime;
			if (currLerpTime >= lerpTime)
				currLerpTime = lerpTime;
		}

		float perc = (currLerpTime / lerpTime) * distance;
		if(keyHit == true)
		transform.position = Vector3.Lerp (currPos, player.transform.position  + offset, perc);

		if (transform.position == player.transform.position + offset) {
			currLerpTime = 0;
			keyHit = false;
			currPos = player.transform.position + offset;
			transform.position = currPos;
		}
	}

	void Type2()
	{
		if (Input.GetKey ("w") || Input.GetKey ("d") || Input.GetKey ("a") || Input.GetKey ("s")) {
			lerpTime += Time.deltaTime;
		}

		if (Input.GetKeyUp ("w") || Input.GetKeyUp ("d") || Input.GetKeyUp ("a") || Input.GetKeyUp ("s")) {
			keyHit = true;
		}
		if (lerpTime >= 7.0f)
			keyHit = true;

		if (keyHit == true ) {
			currLerpTime += Time.deltaTime;
			if (currLerpTime >= lerpTime) {
				currLerpTime = lerpTime;

			}
				
	}
		float perc = (currLerpTime / lerpTime) * distance;
		if(keyHit == true)
			transform.position = Vector3.Lerp (currPos, player.transform.position  + offset, perc);

		if (transform.position == player.transform.position + offset) {
			currLerpTime = 0;
			lerpTime = 5.0f;
			keyHit = false;
			currPos = player.transform.position + offset;
			transform.position = currPos;
		}

}
}
