using UnityEngine;
using System.Collections;

public class NewMovement : MonoBehaviour {


	public GameObject forward;

	public GameObject right;

	public Vector3 playerForward;

	public Vector3 playerRight;


	//public Transform cam = Camera.main.transform;


	//public Vector3 cameraRelativeRight = cam.TransformDirection(Vector3.right);


	public float speed = 10.0f;

	//public Vector3 moveDirection;

	// Use this for initialization
	void Start () {

		forward = GameObject.Find("Forward");

		right = GameObject.Find("Right");
	
	}
	
	// Update is called once per frame
	void Update () {


		playerForward = forward.transform.position - this.transform.position;

		playerRight = right.transform.position - this.transform.position;


		//print(playerForward);



	
		if(Input.GetKey("w")){

			//playerForward.x = 0.0f;

			playerForward.y = 0.0f;

			this.rigidbody.velocity = playerForward * speed;

		}


		if(Input.GetKey("s")){
			
			//playerForward.x = 0.0f;
			
			playerForward.y = 0.0f;
			
			this.rigidbody.velocity = -playerForward * speed;
			
		}





		if(Input.GetKey("a")){
			
			//playerForward.x = 0.0f;
			
			playerRight.y = 0.0f;
			
			this.rigidbody.velocity = -playerRight * speed;
			
		}



		if(Input.GetKey("d")){
			
			//playerForward.x = 0.0f;
			
			playerRight.y = 0.0f;
			
			this.rigidbody.velocity = playerRight * speed;
			
		}


	}
}
