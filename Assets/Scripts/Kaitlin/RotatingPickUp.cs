using UnityEngine;
using System.Collections;

public class RotatingPickUp : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 20);
		transform.position = new Vector3(transform.position.x, 1 + Mathf.PingPong(Time.time, 1), transform.position.z);
	}
}
