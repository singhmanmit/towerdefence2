using UnityEngine;
using System.Collections.Generic;

public class Enemy_Health_Bar : MonoBehaviour 
{

	public float Enemy_Health;
	public float Max_Enemy_Health;
	public Texture2D HpBarTexture;
	private float hpBarLength;
	private float Enemy_Percent_Hp;
	public float scale = 50.0f;
	public int tagNumber;
	List<GameObject> myList= new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		Enemy_Health = 300.0f;
		Max_Enemy_Health = 300.0f;
		Enemy_Percent_Hp = (Enemy_Health/Max_Enemy_Health) * 100.0f;
		hpBarLength = 100.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Enemy_Percent_Hp <= 0) 
		{
			//	Dani Start
			for (int i=0; i < myList.Count; i++) {
				myList[i].GetComponent<tower2>().EnemyDead(tagNumber);
			}
			//	Dani End
			
			Destroy(this.gameObject);
		}
	}

	//Drawing the healthbar over the enemies
	void OnGUI()
	{
		if(gameObject.tag == "enemy")
		{
			if (Enemy_Health > 0)
			{
				Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0.0f,-10.0f,0.0f));
				float dist = (this.transform.position-Camera.main.transform.position).magnitude;
				GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(Enemy_Percent_Hp/100))*((1/dist)*scale)/2),((Screen.height-pos.y)+((1/dist))),(hpBarLength*(Enemy_Percent_Hp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
				//GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(percentOfHp/100))*((1/dist)*scale)/2),(((Screen.height-pos.y))-(150*((1/dist)*scale)))*((1/dist)*5),(hpBarLength*(percentOfHp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
			}
		}

	}

	//Calculating the damage that the enemies take from the bullet
	void TakeDamage(float bulletDamage)
	{
		Enemy_Health -= bulletDamage;
		Debug.Log (Enemy_Health);
		if (Enemy_Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
