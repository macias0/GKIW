using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController2 : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{


		Debug.Log ("Item: TriggeredEnter: " + other.gameObject.name);


		if (heldItem == null && other.gameObject.tag == "Item") {

			Debug.Log ("Podnosze item");

			takeItem (other.gameObject);
		}
		else if(heldItem == other.gameObject) {
			Debug.Log ("Wyrzucam item");
			heldItem = null;
		}


		updateSprite ();

	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("Item: TriggerExit: " + other.gameObject.name);
//		if (other.gameObject.tag == "Item")
//			other.gameObject.GetComponent<SphereCollider> ().enabled = true;
		//updateSprite ();
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


			dropItem ();
//			heldItem = null;
		}
	}


	public void takeItem(GameObject item)
	{
		heldItem = item;
		heldItem.SetActive (false);
	}


	public void dropItem()
	{
		if (heldItem) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, Vector3.down, out hit, Mathf.Infinity)) {
				Debug.DrawRay (transform.position, Vector3.down * hit.distance, Color.yellow, 10);
				//Debug.Log ("HIT");
				heldItem.transform.position = hit.point + new Vector3 (0, heldItem.GetComponent<Renderer> ().bounds.size.x / 2, 0);
				//Debug.Log ("Item size" + heldItem.GetComponent<Renderer>().bounds.size);
			} else
				heldItem.transform.position = transform.position;//+ transform.forward * 2.0F;

			heldItem.SetActive (true);
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


	public GameObject getHeldItem()
	{
		return heldItem;
	}

	private GameObject heldItem = null;
	public GameObject itemSprite = null;
}