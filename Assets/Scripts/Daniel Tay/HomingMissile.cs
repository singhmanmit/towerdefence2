using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour {

	public GameObject target;
	public float speed;

	public float autoDestroyAfter;
	public GameObject explosion;
	
	public float homingSensitivity = 0.1f;
	private Vector3 relativePos;
	public float damage ;

	// Use this for initialization
	void Start () {
	
		StartCoroutine (AutoExplode());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (target != null) {
			relativePos = target.transform.position - transform.position;
			//relativePos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos);

			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, homingSensitivity);
		}

		transform.Translate (0, 0, speed * Time.deltaTime, Space.Self);
	}

	void OnTriggerEnter(Collider other) {
		//Damage the other gameobject &amp; then destroy self
		if (other.gameObject.tag == "enemy") {
			//ExplodeSelf ();
			Destroy(gameObject);
		}
	}
	
	private void ExplodeSelf () {
		Instantiate(explosion,transform.position,Quaternion.identity);
		Destroy(gameObject);
	}
	
	private IEnumerator AutoExplode() {
		yield return new WaitForSeconds (autoDestroyAfter);
		ExplodeSelf();
	}
}
