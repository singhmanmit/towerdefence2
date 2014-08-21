using UnityEngine;
using System.Collections;

public class Tower_Health_Bar : MonoBehaviour 
{

	public float Tower_Health;
	public float Max_Tower_Health;
	public Texture2D HpBarTexture;
	private float hpBarLength;
	private float Tower_Percent_Hp;
	public float scale = 50;

	// Use this for initialization
	void Start () 
	{
		Tower_Health = 500.0f;
		Max_Tower_Health = 500.0f;
		Tower_Percent_Hp = (Tower_Health/Max_Tower_Health) * 100.0f;
		hpBarLength = 100.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameObject.tag == "tower")
		{
			if (Tower_Health > 0)
			{
				Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position + new Vector3(0.0f,-10.0f,0.0f));
				float dist = (this.transform.position-Camera.main.transform.position).magnitude;
				GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(Tower_Percent_Hp/100))*((1/dist)*scale)/2),((Screen.height-pos.y)+((1/dist))),(hpBarLength*(Tower_Percent_Hp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
				//GUI.DrawTexture(new Rect(pos.x-((hpBarLength*(percentOfHp/100))*((1/dist)*scale)/2),(((Screen.height-pos.y))-(150*((1/dist)*scale)))*((1/dist)*5),(hpBarLength*(percentOfHp/100))*((1/dist)*scale),10*((1/dist)*scale)),HpBarTexture);
			}
		}

	}
}
