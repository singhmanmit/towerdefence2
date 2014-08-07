using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public Rigidbody projectile;
	public float speed = 50.0f;
	public float seconds;

	GameObject Player;
	CameraGUI player;
	
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<CameraGUI>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))	//&& player.GetPauseState()==false
		{
			//print("WORKS"); //I commented this because it was filling the debuglog too much. DH
			Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation)
				as Rigidbody;
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
			Destroy (instantiatedProjectile.gameObject, seconds);
		}
	}
}