using UnityEngine;
using System.Collections;

public class E_deathSpawn : MonoBehaviour {

	// omars script to drop money and health at random in an enemy dies;


	public GameObject health_pu;
	public GameObject money_pu;


	public int health = 10;


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if(health <= 0)
		{

			int choose = Random.Range(0,100);


			if(choose > 50)
			{
				print("health");
				GameObject PickUp = Instantiate(health_pu, this.transform.position, this.transform.rotation) as GameObject;
				Destroy(this.gameObject);
			}

			if(choose < 50)
			{
				print("money");
				GameObject PickUp = Instantiate(money_pu, this.transform.position, this.transform.rotation) as GameObject;
				Destroy(this.gameObject);
			}



		}






	
	}



	void OnCollisionEnter(Collision col)
	{

		if(col.gameObject.tag == "damage")
		{
			health -= 100;

		}



	}

}
