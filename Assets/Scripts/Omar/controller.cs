﻿using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {

	
	public float speed = 10.0F;
	public float jumpSpeed = 25.0F;
	public float gravity = 60.0F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {

			if(controller.velocity == Vector3.zero)
			{
				audio.Play();

			}





			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	
	
	
	
	
}