using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController2 : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{


		Debug.Log ("Item: TriggeredEnter: " + other.gameObject.name);


		if (heldItem == null && other.gameObject.tag == "Item") {

			Debug.Log ("Podnosze item");

			heldItem = other.gameObject;
			heldItem.SetActive (false);
		}
		else if (heldItem == other.gameObject) {
			Debug.Log ("Wyrzucam item");
			heldItem = null;
		}

		updateSprite ();

	}


	public void updateSprite()
	{
		ItemBase it = null;
		if (heldItem)
			it = heldItem.GetComponent<ItemBase> ();

		itemSprite.GetComponent<ItemSpriteController> ().setSprite (it);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G) && heldItem != null) {

			heldItem.SetActive (true);
			heldItem.transform.position = transform.position;//+ transform.forward * 2.0F;
			Debug.Log("Height of object: " + transform.lossyScale.y);

//			heldItem = null;
		}
	}

	void OnEnable()
	{
		Debug.Log ("onEnable");
		//updateSprite ();
	}

	void OnDisable()
	{
		Debug.Log ("onDisable");
	}


	private GameObject heldItem = null;
	public GameObject itemSprite = null;
}