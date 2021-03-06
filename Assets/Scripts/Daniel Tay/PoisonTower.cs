﻿using UnityEngine;
using System.Collections.Generic;

public class PoisonTower : MonoBehaviour {

	public float rotSpeed;
	public Transform towerHead;	// Head of turret
	public Transform Spawnpoint;	// location of bullet instantiate
	public GameObject bullet;
	public float bulletSpeed = 200.0f;
	
	// 3 values for Tower levels
	private float shootRate = 1.0f;
	private float range;
	public float power = 1.0f;
	
	public float baseShootRate = 1.0f;
	public float basePower = 1.0f;
	public float baseRange = 1.0f;
	
	private float newRange;	// initialize to getting range value from
	private CapsuleCollider myCollider;	// initializa to access capsule collider
	
	Dictionary<int, GameObject> myDictonary =  new Dictionary<int, GameObject>();
	private int firstTag;
	private int secondTag;
	private GameObject fEnemy;
	private Vector3 relPos;
	private Vector3 relPos2;
	private int dictKey;
	private float elapsedtime;
	
	private float number1;
	
	public void RadiusOfCollider() {		// Call this fuction only when the range button is pressed
		
		newRange = gameObject.GetComponent<TowerLevels>().range;	// get the range value from
		myCollider = transform.GetComponent<CapsuleCollider>();	// access Capsule collider of tower
		range = myCollider.radius;		// set range to get collider's radius
		
		range = range + newRange;		// Increase range by the newRange
		myCollider.radius = range;		// Set collider radius to a new range value;
		
		Debug.Log(range);
	}
	
	void Update () {
		// Set the values that will change the Upgrades for this tower.
		float newShootRate = gameObject.GetComponent<TowerLevels>().speed;	// get speed value from 
		float newPower = gameObject.GetComponent<TowerLevels>().power;	// get damage value from
		// Set the elapsed time wich will be used for the fire rate of the tower.
		elapsedtime += Time.deltaTime;
		
		// If the Dictionary has at least one enemy in it.
		if (myDictonary.Count >=1) 
		{
			dictKey = 1;	//Set the dictionary Key to be 1
			
			// LOOP if the dictionary doesn't contain the current key, dictKey goes +1
			while((myDictonary.ContainsKey(dictKey))!= true) 
			{	
				dictKey += 1;	// dictionary go to next element
			}
			
			fEnemy = myDictonary[dictKey];	// Current enemy is the dictKey number
			
			// if the current enemy value isn't null
			if (fEnemy != null)
			{	
				// relative position = position of enemy - position of tower
				relPos = fEnemy.transform.position - transform.position;
				relPos.y = 0;	// set the y value to 0
				//Set target rotation and rotate body of tower to enemy position
				Quaternion targetRotation = Quaternion.LookRotation(relPos);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
				
				// relative position2 = position of enemy - position of the turret of tower
				relPos2 = fEnemy.transform.position - towerHead.transform.position;
				//Set target rotation and rotate turret of tower to enemy position
				Quaternion targetRotation2 = Quaternion.LookRotation(relPos2);
				towerHead.rotation = Quaternion.Lerp(towerHead.transform.rotation, targetRotation2, Time.deltaTime * rotSpeed);
				
				// the shoot rate of the tower is multiplied by the level of the tower
				shootRate = shootRate * newShootRate;
				//Debug.Log(newShootRate);	
				
				//SHOOTING RATE OF TOWER
				if (elapsedtime >= shootRate) 
				{	
					// the power damage of bullet is the multiplication of the base power with the level power
					power = power * newPower;	
					
					// make each instance of bullet contains the power value
					GameObject bulletInstance =  Instantiate(bullet, Spawnpoint.position, Spawnpoint.rotation) as GameObject;
					bulletInstance.GetComponent<BulletScript>().damage = power;
					//bulletInstance.AddForce(Spawnpoint.forward * bulletSpeed);
					bulletInstance.GetComponent<Rigidbody>().AddForce(Spawnpoint.forward * bulletSpeed);
					elapsedtime =0.0f;
					
					// power resets to original damage
					power = basePower;
				}
				shootRate = baseShootRate;	// shoot rate resets to original rate
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		
		
		if (other.gameObject.tag == "enemy") 
		{
			if (myDictonary.Count >= 0) 
			{
				firstTag = other.gameObject.GetComponent<HealthBar>().tagNumber;	// Get tag from enemy
				myDictonary.Add(firstTag, other.gameObject);				// Add Enemy into dictionary with tag #
			}
		}
	}
	
	void OnTriggerExit(Collider other) {	
		
		if (other.gameObject.tag == "enemy") 
		{
			secondTag = other.gameObject.GetComponent<HealthBar>().tagNumber;
			EnemyDead(secondTag);
		}
	}
	
	public void EnemyDead(int Keyvalue) {
		
		myDictonary.Remove(Keyvalue); // remove keytag form dictionary
	}
}
