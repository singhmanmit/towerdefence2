using UnityEngine;
using System.Collections;

public class animations_script : MonoBehaviour {

	void Start () {
		animation.wrapMode =WrapMode.Loop;
		
		animation["idle"].wrapMode=WrapMode.Clamp;
		animation["r_strafe"].wrapMode=WrapMode.Clamp;
		animation["l_strafe"].wrapMode=WrapMode.Clamp;
		animation["jump"].wrapMode=WrapMode.Clamp;
		animation["run"].wrapMode=WrapMode.Clamp;
		animation["backwark"].wrapMode=WrapMode.Clamp;
		animation["shoot"].wrapMode=WrapMode.Clamp;
	}
	
	void Update () {
		 
		animation.CrossFade("idle");
		print("idle");

		if (Input.GetMouseButton(0))
			animation.Play ("shoot");
			print ("shoot");
		if (Input.GetKey (KeyCode.A))
			animation.Play ("r_strafe");
			print ("r_strafe");
		if (Input.GetKey (KeyCode.D))
			animation.Play ("l_strafe");
			print ("l_strafe");
		if (Input.GetKey (KeyCode.W))
			animation.Play ("run");
			print ("run");
		if (Input.GetKey (KeyCode.S))
			animation.Play ("backward");
			print ("backward");
		if (Input.GetKey (KeyCode.Space))
			animation.Play ("jump");
			print ("jump");
		if (Input.GetKey (KeyCode.Space) && Input.GetKey (KeyCode.W))
			animation.Play ("jump");
			print ("jump");
	}
}