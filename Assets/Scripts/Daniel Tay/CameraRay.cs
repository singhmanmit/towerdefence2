using UnityEngine;
using System.Collections;

public class CameraRay : MonoBehaviour {

	public Transform cube;
	public float raycastDist;
	public string tagCheck = "Level Parts";
	public string enemCheck = "enemy";
	public bool checkAllTags = false;

	void Update() {

		bool foundHit = false;

		RaycastHit hit = new RaycastHit();

		foundHit = Physics.Raycast (transform.position, transform.forward, out hit);

//		if (foundHit && !checkAllTags && hit.transform.tag != tagCheck )
//			foundHit = false;
//
//		if (foundHit)
//		{
			cube.position = hit.point;
			cube.rotation = Quaternion.LookRotation (hit.normal);
//		}
	}
}
