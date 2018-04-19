using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		health = 100.0F;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
//			Destroy (gameObject);
			if (respawnController) {
				Debug.Log ("RESPAWNED!");
				Vector3 newPos = respawnController.GetComponent<RespawnPointController> ().getNearestRespawnPoint (transform.position);
				health = 100.0F;
				transform.position = newPos;
			}
		}
	}

	public float health = 100.0F;

	public GameObject winScreen = null;
	public GameObject respawnController = null;
}
