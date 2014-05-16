using UnityEngine;
using System.Collections;

public class CameraGUI : MonoBehaviour {

	public float rayDistance = 100f;
	public TowerNode_Script NODE;
	RaycastHit hitObj;
	Ray ray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("e")){
			Debug.Log("raycast triggered" + ray.direction + "  " + ray.origin);
			grabNode();
		}
	}

	void OnGUI(){
		if (NODE == true) {
			GUI.Box(new Rect(10,10,150,140), "TNode_TESTMENU");
			if (GUI.Button (new Rect (20, 40, 80, 20), "Tower01")) {
					NODE.CreateTower (0);
			}
		
			if (GUI.Button (new Rect (20, 70, 80, 20), "Tower02")) {
					NODE.CreateTower (1);
			}
		
			if (GUI.Button (new Rect (20, 100, 80, 20), "RemoveTower")) {
					NODE.RemoveTower ();
			}
		}
	}

	void grabNode (){
		ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		Debug.DrawRay(ray.origin, (ray.direction * rayDistance), Color.red, 9000);
		if (Physics.Raycast (ray.origin, ray.direction, out hitObj, rayDistance)){
			if(hitObj.collider.gameObject.tag == "Node"){
				Debug.Log("raycast HIT!");
				NODE = hitObj.collider.gameObject.GetComponent<TowerNode_Script>();
			}
			else{
				NODE = null;
			}
		}
	}
}


//.GetComponent<TowerNode_Script>