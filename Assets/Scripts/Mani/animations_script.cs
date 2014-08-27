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
		animation["backwarks"].wrapMode=WrapMode.Clamp;
	}
	
	void Update () {
		 
		animation.CrossFade("idle");
		print("idle");
		
		if (Input.GetKey (KeyCode.A))
			animation.CrossFade ("r_strafe");
			print ("r_strafe");
		if (Input.GetKey (KeyCode.D))
			animation.CrossFade ("l_strafe");
			print ("l_strafe");
		if (Input.GetKey (KeyCode.W))
			animation.CrossFade ("run");
			print ("run");
		if (Input.GetKey (KeyCode.S))
			animation.CrossFade ("backward");
			print ("backward");
		if (Input.GetKey (KeyCode.Space))
			animation.CrossFade ("jump");
			print ("jump");

	}
}
