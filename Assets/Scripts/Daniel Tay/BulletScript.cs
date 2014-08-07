using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float damage = 1;

	// Update is called once per frame
	void Update () {
	
		//Debug.Log(damage);
		Destroy(gameObject, 3);
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "enemy") 
		{
			Destroy(gameObject);
		}
	}
}
