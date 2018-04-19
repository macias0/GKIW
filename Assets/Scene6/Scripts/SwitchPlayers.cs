using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int i=1; i<players.Length; ++i)
			players[i].SetActive(false);
		activePlayer = players [0];
	}

	// Update is called once per frame
	void Update () {

		GameObject nextActivePlayer = activePlayer;

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			nextActivePlayer = players [0];
		} 
		else if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			nextActivePlayer = players [1];
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			nextActivePlayer = players [2];
		}

		if (nextActivePlayer != activePlayer) {
			activePlayer.SetActive (false);
			activePlayer = nextActivePlayer;
			activePlayer.SetActive (true);
			activePlayer.GetComponent<ItemController2> ().updateSprite ();
		}

	}


	public GameObject activePlayer = null;

	public GameObject[] players;

}
