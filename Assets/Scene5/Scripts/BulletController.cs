﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {



	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			Debug.Log ("Trafiam w przeciwnika!");
			collision.gameObject.GetComponent<EnemyHealthController> ().health -= 50.0F;
		}

		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}