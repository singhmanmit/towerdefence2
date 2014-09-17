using UnityEngine;
using System.Collections;

public class CameraGUI : MonoBehaviour {
	
	public float rayDistance = 100f;
	public TowerNode_Script NODE;
	RaycastHit hitObj;
	Ray ray;
	public int MenuPositionX = 0;
	public int MenuPositionY = 0;
	bool Pausegame = false;
	
	GameObject Player;
	Currency player;

	public Texture2D crosshair;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		Player = GameObject.FindGameObjectWithTag("Player");
		player = Player.GetComponent<Currency>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Pausegame == true){
			Time.timeScale = 0.0001f;
			Screen.showCursor = true;
		}
		else{
			Time.timeScale=1;
			Screen.showCursor = false;
		}
		
		if (Input.GetKeyDown("e")&& NODE==false){
			Debug.Log("raycast triggered" + ray.direction + "  " + ray.origin);
			grabNode();
		}
		if(Input.GetKeyDown("e")&& Pausegame==true){
			NODE=null;
			Pausegame = false;
		}
	}
	
	public bool GetPauseState(){
		return Pausegame;
	}
	
	//will need to edit size calculation when UI is finalized
	//also edit naming system once towers are finalized, if needed
	void OnGUI(){

		//GUI.DrawTexture(new Rect(Screen.width / 2 - 37.5f, Screen.height/2 - 37.5f, 75, 75), crosshair);	// draws the crosshair

		if (NODE == true) {
			Pausegame = true;
			//creates a menu based on size of buttons and number of towers in the list
			GUI.Box(new Rect(MenuPositionX,MenuPositionY, 160, (NODE.StartTowers.Count+3)*30), "TNode_TESTMENU");
			if(NODE.StartTowers.Count>0){
				for(int i = 1; i<=NODE.StartTowers.Count; i++){
					if(player.MoneyHeld<=10 || NODE.IsOccupied==true){
						GUI.enabled = false;	
					}
					else{
						GUI.enabled = true;
					}
					if (NODE.StartTowers[i-1] == true){
						if (GUI.Button (new Rect (MenuPositionX+10, MenuPositionY+(i*30), 130, 20), "Tower" +i)) {
							NODE.CreateTower (i-1);
							player.MoneyHeld-=10;
						}
					}
					else{
						if (GUI.Button (new Rect (MenuPositionX+10, MenuPositionY+(i*30), 130, 20), "EMPTYARRAYSLOT")) {
						}
					}
				}
			}

			if(NODE.IsOccupied==false){
				GUI.enabled = false;	
			}
			else{
				GUI.enabled = true;
				int tempS = NODE.CurrentTower.GetComponent<TowerLevels>().CurrentSpeedLevel;
				int tempP = NODE.CurrentTower.GetComponent<TowerLevels>().CurrentPowerLevel;
				int tempR = NODE.CurrentTower.GetComponent<TowerLevels>().CurrentRangeLevel;


				GUI.enabled = false;
				if (NODE.CurrentTower.GetComponent<TowerLevels>().SpeedList[tempS].cost<player.MoneyHeld){
					GUI.enabled =true;
				}
				if (GUI.Button(new Rect(MenuPositionX, MenuPositionY+((NODE.StartTowers.Count+1)*30), 50, 20), "Speed")){
					player.MoneyHeld-=NODE.CurrentTower.GetComponent<TowerLevels>().SpeedList[tempS].cost;
					NODE.CurrentTower.GetComponent<TowerLevels>().CurrentSpeedLevel+=1;
				}

				GUI.enabled = false;
				if (NODE.CurrentTower.GetComponent<TowerLevels>().RangeList[tempR].cost<player.MoneyHeld){
					GUI.enabled =true;
				}
				if (GUI.Button(new Rect(MenuPositionX+50, MenuPositionY+((NODE.StartTowers.Count+1)*30), 50, 20), "Range")){
					player.MoneyHeld-=NODE.CurrentTower.GetComponent<TowerLevels>().RangeList[tempR].cost;
					NODE.CurrentTower.GetComponent<TowerLevels>().CurrentRangeLevel+=1;
				}

				GUI.enabled = false;
				if (NODE.CurrentTower.GetComponent<TowerLevels>().PowerList[tempP].cost<player.MoneyHeld){
					GUI.enabled =true;
				}
				if (GUI.Button(new Rect(MenuPositionX+100, MenuPositionY+((NODE.StartTowers.Count+1)*30), 50, 20), "Power")){
					player.MoneyHeld-=NODE.CurrentTower.GetComponent<TowerLevels>().PowerList[tempP].cost;
					NODE.CurrentTower.GetComponent<TowerLevels>().CurrentPowerLevel+=1;
				}
			}



			if(NODE.IsOccupied==false){
				GUI.enabled = false;	
			}
			else{
				GUI.enabled = true;
			}
			if (GUI.Button (new Rect (MenuPositionX+10, MenuPositionY+((NODE.StartTowers.Count+2)*30), 130, 20), "SellTower")) {
				NODE.RemoveTower ();
				player.MoneyHeld+=5;
			}
		}
	}
	
	void grabNode (){
		ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		Debug.DrawRay(ray.origin, (ray.direction * rayDistance), Color.red, 9000);
		if (Physics.Raycast (ray.origin, ray.direction, out hitObj, rayDistance)){
			if(hitObj.collider.gameObject.tag == "Node"){
				//Debug.Log("raycast HIT!");
				NODE = hitObj.collider.gameObject.GetComponent<TowerNode_Script>();
			}
			else{
				NODE = null;
			}
		}
	}
}


