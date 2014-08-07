using UnityEngine;
using System.Collections;

public class animations_script : MonoBehaviour {

	void Start () {
		animation.wrapMode =WrapMode.Loop;
		
		animation["idle"].wrapMode=WrapMode.Clamp;
		animation["walk"].wrapMode=WrapMode.Clamp;
		
	//	animation.Stop();
	}
	
	void Update () {
		animation.CrossFade("idle");
		print("idle");
		
		if (Input.GetKey (KeyCode.RightArrow)|| Input.GetKey (KeyCode.LeftArrow))
				animation.CrossFade ("walk");
				print ("Moved Forward");

		/*if (Input.GetButtonDown ("Horizontal"))
				animation.CrossFade ("walk");
				print ("Moved Forward");*/
		
		/*
		if (Input.GetKey (KeyCode.LeftArrow)) 
			animation.CrossFade("strafeLeft");
		
		if(Mathf.Abs(Input.GetAxis("Vertical")) > .1)
			animation.CrossFade("sprint");
		
		if (Input.GetKey (KeyCode.Space)) 
			animation.CrossFade("jump");
		
		if (Input.GetKey (KeyCode.DownArrow)) 
			animation.CrossFade("crouch");
		
		if (Input.GetKey (KeyCode.DownArrow)&&Input.GetKey (KeyCode.UpArrow))
			animation.CrossFade("crouchRun");
		
		if(Input.GetKey (KeyCode.RightArrow)&&Input.GetKey (KeyCode.DownArrow))
			animation.CrossFade ("crouchStrafeRight");
		
		if(Input.GetKey (KeyCode.LeftArrow)&&Input.GetKey (KeyCode.DownArrow))
			animation.CrossFade ("crouchStrafeLeft");
			*/

	}
}
