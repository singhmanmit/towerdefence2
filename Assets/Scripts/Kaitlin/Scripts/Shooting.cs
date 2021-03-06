﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public Rigidbody projectile;
	public float speed = 50.0f;
	public float seconds;

	public GameObject target;
	private Vector3 relativePos;
	private float rotSpeed = 150.0f;

	GameObject Player;
	CameraGUI player;

	float shootFlag=0;

	IEnumerator WaitAndShoot(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		relativePos = target.transform.position - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(relativePos);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
		
		//print("WORKS"); //I commented this because it was filling the debuglog too much. DH
		Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation)
			as Rigidbody;
		instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
		Destroy (instantiatedProjectile.gameObject, seconds);
		shootFlag = 0;
	}

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<CameraGUI>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0))	//&& player.GetPauseState()==false
		{
			if(shootFlag==0){
				shootFlag=1;
				StartCoroutine(WaitAndShoot(.25F));
			}
		}
	}
}