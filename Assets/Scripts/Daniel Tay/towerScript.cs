using UnityEngine;
using System.Collections.Generic;

public class towerScript : MonoBehaviour {
	
	/* Dani T. 
	 * 
	 * This script uses a collider to detect enemies and are added into a dictionary
	 * the turret rotates facing the first enemy in the dictionary and 
	 * attack them instantiating bullets
	 * */
	
	public float rotSpeed;
	public Transform turretSpawn;	// Head of turret
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
	
	public void RadiusOfCollider() {		// Call this fuction only when the range button is pressed

		newRange = gameObject.GetComponent<TowerLevels>().range;	// get the range value from
		myCollider = transform.GetComponent<CapsuleCollider>();	// access Capsule collider of tower
		range = myCollider.radius;		// set range to get collider's radius

		range = range + newRange;		// Increase range by the newRange
		myCollider.radius = range;		// Set collider radius to a new range value;

		Debug.Log(range);
	}

	void Update () {

		float newShootRate = gameObject.GetComponent<TowerLevels>().speed;	// get speed value from 
		float newPower = gameObject.GetComponent<TowerLevels>().power;	// get damage value from
		elapsedtime += Time.deltaTime;

		if (myDictonary.Count >=1) 
		{
			dictKey = 1;	//----------------> Check for possible errors
			
			while((myDictonary.ContainsKey(dictKey))!= true) 
			{	// while the dictionary's current key doesn't exist
				dictKey += 1;	// dictionary go to next element
			}
			
			fEnemy = myDictonary[dictKey];
			
			if (fEnemy != null)
			{	//If there is a value
				relPos = fEnemy.transform.position - transform.position;
				relPos.y = 0;
				Quaternion targetRotation = Quaternion.LookRotation(relPos);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
				
				relPos2 = fEnemy.transform.position - turretSpawn.transform.position;
				Quaternion targetRotation2 = Quaternion.LookRotation(relPos2);
				turretSpawn.transform.rotation = Quaternion.Lerp(turretSpawn.transform.rotation, targetRotation2, Time.deltaTime * rotSpeed);

				shootRate = shootRate * newShootRate;	// the shoot rate of the tower is multiplied by the level of the tower
				Debug.Log(newShootRate);	
				//SHOOTING RATE OF TURRET
				if (elapsedtime >= shootRate) 
				{	
					power = power * newPower;	// the power damage of bullet is the multiplication of the base power with the level power

					// make each instance of bullet contains the power value
					GameObject bulletInstance =  Instantiate(bullet, Spawnpoint.position, Spawnpoint.rotation) as GameObject;
					bulletInstance.GetComponent<BulletScript>().damage = power;
					//bulletInstance.AddForce(Spawnpoint.forward * bulletSpeed);
					bulletInstance.GetComponent<Rigidbody>().AddForce(Spawnpoint.forward * bulletSpeed);
					elapsedtime =0.0f;

					//Debug.Log(power);	// debugs damage being outputted by bullet
					power = basePower;	// power resets to original damage
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
