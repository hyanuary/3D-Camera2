using UnityEngine;
using System.Collections;

public class PlayerMomvement : MonoBehaviour {

    public float speed = 1;
    public float turn = 10000;




	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
  
		//move left to right
		float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate(horizontal, 0,0 );


        //move front to back
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

		//turn the player around
		float turn1 = turn * Time.deltaTime;

		if(Input.GetKey("e"))
			transform.Rotate(0, turn1, 0); 

		if (Input.GetKey ("q"))
			transform.Rotate (0, -turn1, 0);

	

    }


}
