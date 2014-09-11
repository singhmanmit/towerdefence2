using UnityEngine;
using System.Collections;

public class animation_bully : MonoBehaviour {
	
	void Start () {
		animation.wrapMode =WrapMode.Loop;
		
		animation["idle"].wrapMode=WrapMode.Clamp;
		animation["run"].wrapMode=WrapMode.Clamp;
		animation["death"].wrapMode=WrapMode.Clamp;
	}
	
	void Update () {
		
		animation.CrossFade("idle");
		print("idle");;

		if (Input.GetKey (KeyCode.A))
			animation.Play ("run");
		print ("run");
	}
}
