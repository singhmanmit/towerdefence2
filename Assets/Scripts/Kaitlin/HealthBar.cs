using UnityEngine;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour {
	
	public static float curHp = 5.0f;
	public static float maxHp = 300.0f;
	public Texture2D HpBarTexture;
	private float hpBarLength;
	private float percentOfHp;

	public float health = 5.0f;
	public float dmgPercent;
	private float dmg;

	public float scale = 50;

	// Dani Start
	public int tagNumber;
	List<GameObject> myList= new List<GameObject>();
	// Dani End

	void Start() {

		hpBarLength = 100.0f;
		percentOfHp = 100.0f;
	}

	void OnGUI () 
	{
		if(gameObject.tag == "enemy")
		{
			if (curHp > 0)
			{
				Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0.0f,-10.0f,0.0f));
				float dist = (this.transform.position-Camera.main.transform.position).magnitude;
				GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(percentOfHp/100))*((1/dist)*scale)/2),((Screen.height-pos.y))-(150*((1/dist)*scale)),(hpBarLength*(percentOfHp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
			}
		}

		//	Dani Commented this out because this script shouldn't be ADDED to any tower. Please make a new script sorely for the tower health bar.
//		if(gameObject.tag == "tower")
//		{
//			if (curHp > 0)
//			{
//				Vector3 pos2 = Camera.main.WorldToScreenPoint(this.transform.position);
//				float dist2 = (this.transform.position-Camera.main.transform.position).magnitude;
//				GUI.DrawTexture(new Rect(pos2.x-((hpBarLength*(percentOfHp/100))*((1/dist2)*scale)/2),((Screen.height-pos2.y))-(150*((1/dist2)*scale)),(hpBarLength*(percentOfHp/100))*((1/dist2)*scale),10*((1/dist2)*scale)),HpBarTexture);
//			}
//		}
		/*if(gameObject.tag == "Player")
		{
			if (curHp > 0)
			{
				//Vector3 pos2 = Camera.main.WorldToScreenPoint(this.transform.position);
				//float dist2 = (this.transform.position-Camera.main.transform.position).magnitude;
				GUI.DrawTexture(new Rect(10,10,(hpBarLength*(percentOfHp/100)),10,HpBarTexture));
			}
		}*/
	}
	
	void Update () {

		if(percentOfHp <= 0)
		{
			//	Dani Start
			for (int i=0; i < myList.Count; i++) {
				myList[i].GetComponent<tower2>().EnemyDead(tagNumber);
			}
			//	Dani End

			Destroy(this.gameObject);
		}
	}

	void HealthToPercentage() {

		// health value "5" = percentOfHP "100"
		// 1hp = ?%
		health = health - dmg;
		dmgPercent = (dmg * percentOfHp) / health;
		Debug.Log(dmgPercent);
	}

	//	Dani Start
	/*	NOTES:
	// Tag for the collision of bullets changed from "enemydamage" to "damage" */
	void OnTriggerEnter(Collider collision) {

		if(collision.gameObject.tag == "damage")
		{
			// get damage value from bullet
			dmg = collision.gameObject.GetComponent<BulletScript>().damage;
			HealthToPercentage();
			// substract percentOfHp by the damage value
			percentOfHp -= dmgPercent;
		}

		if(collision.gameObject.tag == "tower") {
			
			myList.Add(collision.gameObject);
		}
		//	Dani End
	}
}
