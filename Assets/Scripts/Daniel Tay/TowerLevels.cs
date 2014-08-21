using UnityEngine;
using System.Collections;

/* This script should do:
 * increase the speed (shoot rate of tower)
 * increase the range of the tower
 * increase the power of the bullet
 * */

public class TowerLevels : MonoBehaviour {
	
	// public values
	public int sCost = 100;
	public int rCost = 100;
	public int pCost = 100;

	// private values
	public float speed, range, power;
	private int level;
	private int speedLevel, rangeLevel, powerLevel;
	public int CostMultiplier = 2;

	GameObject Player;
	Currency player;

	void Start() {
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<Currency>();

		level =0;
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