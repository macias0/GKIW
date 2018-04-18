using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		player2.SetActive (false);
		player3.SetActive (false);
		activePlayer = player1;
	}

	// Update is called once per frame
	void Update () {

		GameObject nextActivePlayer = activePlayer;

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			nextActivePlayer = player1;
		} 
		else if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			nextActivePlayer = player2;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			nextActivePlayer = player3;
		}

		if (nextActivePlayer != activePlayer) {
			activePlayer.SetActive (false);
			activePlayer = nextActivePlayer;
			activePlayer.SetActive (true);
			activePlayer.GetComponent<ItemController2> ().updateSprite ();
		}

	}


	private GameObject activePlayer = null;

	public GameObject player1 = null;
	public GameObject player2 = null;
	public GameObject player3 = null;
}
