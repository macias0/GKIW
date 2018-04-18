using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//FIRE!
		if (Input.GetKeyDown (KeyCode.F) && bullet) {
			GameObject obj = Instantiate (bullet);
			obj.transform.forward = transform.forward;
			obj.transform.position = transform.position + transform.forward * 2.0F + new Vector3 (0.0F, 2.0F, 0.0F);
			obj.SetActive (true);
			obj.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Force);

		}
	}

	public GameObject bullet = null;
	public float bulletSpeed = 5.0F;
}
