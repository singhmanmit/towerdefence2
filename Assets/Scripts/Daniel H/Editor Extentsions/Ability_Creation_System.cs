using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Ability_Creation_System : EditorWindow{
	List<Ability> RangerAbilities;
	List<Ability> BrwalerAbilities;
	List<Ability> RogueAbilities;

	[MenuItem("Window/Ability Creator")]
	public static void ShowWindow(){
		EditorWindow.GetWindow (typeof(Ability_Creation_System));
	}
	void OnGUI(){

	}
}

[System.Serializable]
public class Ability {
	public string NameOfAbility;
	public KeyCode ButtonUsedForAbility;
	public bool DoesASingleChunckOfDmg;
	public float Damage;
	public bool IsAOE;
	public float Radius;
	public bool IsBasedOnPlayer;
	public bool IsBasedOnImpact;
	public bool DoesDmgFalloff;
	public float MinimumDistanceForDmgFalloff;
	public float RateOfDmgFalloff;
	public bool DoesSlow;
	public float SlowRate;
	public bool HasCoolDown;
	public float CoolDown;
	public bool DoesDmgOverTime;
	public float TotalDamage;
	public float Duration;
	public bool IsMelee;
	public bool IsRanged;
	public float RangeOfAbility;
}

//Event.current.keyCode