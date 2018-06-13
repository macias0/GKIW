using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController3 : MonoBehaviour {



	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			Debug.Log ("Trafiam w przeciwnika!");
			EnemyHealthController3 ehc3 = collision.gameObject.GetComponent<EnemyHealthController3> ();
			if(ehc3)
				ehc3.health -= 50.0F;
			EnemyHealthController2 ehc2 = collision.gameObject.GetComponent<EnemyHealthController2> ();
			if (ehc2)
				ehc2.health -= 50;
		
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
