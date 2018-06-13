using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Item: TriggeredEnter: " + other.gameObject.name);


		if (heldItem == null && other.gameObject.tag == "Item") {

			Debug.Log ("Podnosze item");

			heldItem = other.gameObject;
			heldItem.SetActive (false);
		}
		else if (heldItem == other.gameObject) {
			heldItem = null;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G) && heldItem != null) {
			heldItem.SetActive (true);
			heldItem.transform.position = transform.position;
			//heldItem = null;
		}
	}

	public bool hasItem()
	{
		return heldItem != null;
	}
	private GameObject heldItem = null;
}
