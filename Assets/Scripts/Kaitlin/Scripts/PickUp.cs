using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{
	public float health;

	// Use this for initialization
	void Start () 
	{
		health = 20.0f;	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			if(this.gameObject.tag == "health")
			{
				collider.SendMessage("addHealth", health, SendMessageOptions.DontRequireReceiver);
				Destroy(this.gameObject);
				Debug.Log("You picked up health!");
			}

			if(this.gameObject.tag == "power")
			{
				Destroy (this.gameObject);
				Debug.Log ("You picked up a power up!");
			}

			if(this.gameObject.tag == "currency")
			{
				Destroy(this.gameObject);
				Debug.Log ("You picked up money!");
			}
		}
	}
}