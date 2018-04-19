using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		health = 100.0F;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
			winScreen.SetActive (true);
		}
	}

	public float health = 100.0F;

	public GameObject winScreen = null;
}
