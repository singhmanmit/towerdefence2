﻿using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {



	public Texture btnTexture;

	private float x = 475.5f;
	private float y = 553.6f;
	private float one = 444.4f;
	private float two = 100.9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI()
	{
		if (GUI.Button(new Rect((Screen.width/ 2) - (one/2), (Screen.height / 2)+ two + 90, one, two), btnTexture, GUIStyle.none))
		{
			Application.LoadLevel("LEVEL_2_VER_2_0");
		}
	}


}
