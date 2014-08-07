using UnityEngine;
using System.Collections;

/* This script should do:
 * increase the speed (shoot rate of tower)
 * increase the range of the tower
 * increase the power of the bullet
 * */

public class TowerLevels : MonoBehaviour {
	
	// public values
	public int money = 300;
	private int sCost, rCost, pCost;

	// private values
	public float speed, range, power;
	private int level;
	private int speedLevel, rangeLevel, powerLevel;

	void Start() {
		level =0;
		sCost = 100;
		rCost = 100;
		pCost = 100;
		speedLevel = level;
		rangeLevel = level;
		powerLevel = level;
		power = 1.5f;
		speed = 1.4f;
	}

	// 	Each level function
	private void Level1() {
		Debug.Log ("level 1");
		// This is start level
		speed = 1.0f;
		range = 0.0f;
		power = 1.5f;
	}
	private void Level2() {
		Debug.Log ("level 2");
		// This is bought with 100 coins
		speed = 0.8f;
		range = 0.5f;
		power = 2.0f;
	}
	private void Level3() {
		Debug.Log ("level 3");
		// This is bought with 200 coins
		speed = 0.6f;
		range = 1.5f;
		power = 2.5f;
	}
	private void Level4() {
		Debug.Log ("level 4");
		// This is bought with 400 coins
		speed = 0.4f;
		range = 2.0f;
		power = 3.0f;
	}
	private void Level5() {
		Debug.Log ("level 5");
		// This is bought with 800 coins
		speed = 0.2f;
		range = 2.5f;
		power = 3.5f;
	}

	public void OnGUI(){
		if (GUI.Button(new Rect(10, 10, 50, 50), "Speed"))
		{
			// level only increases with money
			if (money >= sCost) {	// if the money is higher or equal to the cost of the speed level
				money = money - sCost;
				speedLevel +=1;
				sCost = sCost * 2;
			}
			Debug.Log("Speed ");
			if (speedLevel == 1)
				Level1();
			if (speedLevel == 2)
				Level2();
			if (speedLevel == 3)
				Level3();
			if (speedLevel == 4)
				Level4();
			if (speedLevel == 5)
				Level5();
		}
		
		if (GUI.Button(new Rect(10, 100, 50, 50), "Range"))
		{

			// level only increases with money
			if (money >= rCost) {
				money = money - rCost;
				rangeLevel +=1;
				rCost = rCost * 2;
			}
			Debug.Log("Range ");
			if (rangeLevel == 1)
				Level1();
			if (rangeLevel == 2)
				Level2();
			if (rangeLevel == 3)
				Level3();
			if (rangeLevel == 4)
				Level4();
			if (rangeLevel == 5)
				Level5();

			if (rangeLevel<=5){
				this.gameObject.GetComponent<towerScript>().RadiusOfCollider();
			}
		}
		
		if (GUI.Button(new Rect(10, 200, 50, 50), "Power"))
		{
			// level only increases with money
			if (money >= pCost) {
				money = money - pCost;
				powerLevel +=1;
				pCost = pCost * 2;
			}
			Debug.Log("Power ");
			if (powerLevel == 1)
				Level1();
			if (powerLevel == 2)
				Level2();
			if (powerLevel == 3)
				Level3();
			if (powerLevel == 4)
				Level4();
			if (powerLevel == 5)
				Level5();
		}
	}
}



/* Levels
 * 1.- speed, range, power
 * 2.- speed, range, power
 * 3.- speed, range, power
 * 4.- speed, range, power
 * 5.- speed, range, power
 * 
 * How it works?
 * player will have a GUI that shows his money, and the tower information as:
 * # speed, # range, # power.
 * each power starts from level 1 and each are be upgradeable separately
 * each upgrade has 5 levels.
 */