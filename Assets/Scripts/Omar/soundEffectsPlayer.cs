using UnityEngine;
using System.Collections;

public class soundEffectsPlayer : MonoBehaviour {




	public AudioClip shoot;
	public AudioClip jump;
	public AudioClip hit;
	public AudioClip health;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		if(Input.GetMouseButtonDown(0))
		{

			audio.PlayOneShot(shoot);

		}


		if(Input.GetKeyDown("space"))
		{
			
			audio.PlayOneShot(jump);
			
		}
	
	}






	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "enemy")
		{
			print("HEYYYYY");
			audio.PlayOneShot(health);

		}




	}



}
