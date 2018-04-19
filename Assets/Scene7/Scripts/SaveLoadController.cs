using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Text;
using System.IO;

public class SaveLoadController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		playerController = GetComponent<SwitchPlayers> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F5)) {

			saveGame ();

		} else if (Input.GetKeyDown (KeyCode.F6)) {
			//load
			loadGame();
		}
	}


	void saveGame()
	{
		//save

		XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));

		PlayerData data  = new PlayerData();
		for (int i = 0; i < playerController.players.Length; ++i) {
			if (playerController.players [i] == playerController.activePlayer) {
				data.id = i;
				break;
			}
		}

		data.pos = playerController.activePlayer.transform.position;


		data.itemId = -1; //if empty hands
		for (int i = 0; i < itemsToSave.Length; ++i) {
			if (playerController.activePlayer.GetComponent<ItemController2> ().getHeldItem () == itemsToSave [i]) {
				data.itemId = i;
				break;
			}
		}

		using (StreamWriter stream = new StreamWriter ("data.xml", false, Encoding.UTF8)) {
			serializer.Serialize (stream, data);
		}

		Debug.Log ("Game saved!");
	}


	void loadGame()
	{
		if (File.Exists ("data.xml")) {
			XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));

			PlayerData data;

			using (StreamReader stream = new StreamReader ("data.xml")) {
				data = serializer.Deserialize (stream) as PlayerData;
			}

			int activePlayerID = -1;

			for (int i = 0; i < playerController.players.Length; ++i) {
				if (playerController.players [i] == playerController.activePlayer) {
					activePlayerID = i;
					break;
				}
			}

			if (activePlayerID == data.id) {
				Debug.Log ("Game loaded!");



				int currentItem = -1; //if empty hands
				for (int i = 0; i < itemsToSave.Length; ++i) {
					if (playerController.activePlayer.GetComponent<ItemController2> ().getHeldItem () == itemsToSave [i]) {
						currentItem = i;
						break;
					}
				}


				if (data.itemId != currentItem) {
					//drop old item
					Debug.Log("Wyrzucam stary item");
					playerController.activePlayer.GetComponent<ItemController2> ().dropItem();
					if (data.itemId != -1) {
						Debug.Log ("Podnosze nowy item");
						//TODO zmienic pos itema
						itemsToSave [data.itemId].transform.position = respawnController.GetComponent<RespawnPointController>().getNearestRespawnPoint(data.pos);
						//playerController.activePlayer.GetComponent<ItemController2> ().takeItem (itemsToSave [data.itemId]);
					}

				}

				playerController.activePlayer.transform.position = respawnController.GetComponent<RespawnPointController>().getNearestRespawnPoint(data.pos);
			}


		}
	}


	private SwitchPlayers playerController = null;
	public GameObject[] itemsToSave;
	public GameObject respawnController = null;
}
