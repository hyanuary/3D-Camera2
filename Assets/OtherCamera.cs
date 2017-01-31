using UnityEngine;
using System.Collections;

public class OtherCamera : MonoBehaviour {

	//animation curve variables -- needing future improvement
	public AnimationCurve zoomMode;
	public float zoomSpeed;
	public float zoomTime; 
	public float damping = 1000;


	//lerping part
	private Vector3 startPos;
	private Vector3 currPos;
	public float distance;

	//time limit for how long can the player move around (type2 only)
	public float lerpTimeAdd;
	//variables for when the start and when to finish the movement
	public float lerpTime = 5;
	public float currLerpTime = 0;
	// for makign sure it will move when the button is pressed
	public bool keyHit = false;

	//bool for choosing a type
	public bool type1On = false;
	public bool type2On = false;

	//offset variables
	Vector3 offset;

	public GameObject player;
	// Use this for initialization
	void Start () {
		
		offset = (transform.position - player.transform.position) ;
		startPos = transform.position;
	}

	
	// Update is called once per frame
	void Update () {
		
		//OpenOut ();

		if( type1On)
		Type1 (); //camera moving towards the player after inserting a button

		if( type2On)
		Type2 (); //the type of camera that have a certain lag

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
		if (lerpTime >= lerpTimeAdd) // an if statements that control for how long the player can move before the camera will
			keyHit = true;				//follow the player

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
