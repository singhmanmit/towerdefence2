using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			if(this.gameObject.tag == "healthpickup")
			{
				Destroy(this.gameObject);
				Debug.Log("You picked up health!");
			}
		}
	}
}
