﻿using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour {

	public Texture btnTexture;
	public int MoneyHeld;
	public int PassiveMoneyGainRate=10;
	public int PassiveMoneyAmount=2;
	float Timer;

	// Use this for initialization
	void Start () {
		Timer=PassiveMoneyGainRate;
	}
	
	// Update is called once per frame
	void Update () {
		Timer-=Time.deltaTime;
		if(Timer<=0){
			MoneyHeld+=PassiveMoneyAmount;
			Timer=PassiveMoneyGainRate;
		}
	}

	void OnGUI(){
		GUI.Box(new Rect(1100,Screen.height-40,140,30),btnTexture,"Money: " + MoneyHeld);
	}

	public void AddMoney(int amount){
		MoneyHeld += amount;
	}
}