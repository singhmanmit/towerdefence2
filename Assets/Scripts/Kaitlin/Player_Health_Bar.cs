	using UnityEngine;
using System.Collections;

public class Player_Health_Bar : MonoBehaviour 
{

	public float player_Health;
	public Texture3D ColoringCrayon;
	public Texture2D BackgroungBase;
	public Material mat;
	public float x;
	public float y;
	public float height;
	public float width;


	// Use this for initialization
	void Start () 
	{
		player_Health = 100.0f;
		x = 0.0f;
		y = 0.0f;
		height = 50.0f;

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		Rect background = new Rect(x, y, width + 5, height + 5);
		GUI.DrawTexture(background, BackgroungBase);
		if (Event.current.type.Equals(EventType.Repaint))
		{
			Rect box = new Rect(x, y, width, height);
			Graphics.DrawTexture(box, ColoringCrayon, mat);
		}
	}
}
