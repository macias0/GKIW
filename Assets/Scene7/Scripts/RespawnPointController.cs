using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(draw)
			for (int i = 0; i < respawnPoints.Length; ++i) {
				Debug.DrawLine (respawnPoints [i].transform.position, respawnPoints [i].transform.position + new Vector3(0.0F, 10.0F, 0.0F), Color.green);
			}
	}

	public Vector3 getNearestRespawnPoint(Vector3 pos)
	{
		int resultIdx = -1;
		float lastDistance = Mathf.Infinity;
		for (int i = 0; i < respawnPoints.Length; ++i) {
			float dist = Vector3.Distance (pos, respawnPoints [i].transform.position); 
			if (dist < lastDistance) {
				resultIdx = i;
				lastDistance = dist;
			}
		}
		if (resultIdx != -1)
			return respawnPoints [resultIdx].transform.position;
		else
			return Vector3.one;
	}

	public GameObject[] respawnPoints;
	public bool draw = true;
}
