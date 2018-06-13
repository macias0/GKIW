using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		player1.SetActive (true);
		player2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			player2.SetActive (false);
			player1.SetActive (true);
		} 
		else if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			player1.SetActive (false);
			player2.SetActive (true);
		}
	}


	public GameObject player1 = null;
	public GameObject player2 = null;
}
