using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {



	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			
			GameObject playerItem = other.gameObject.GetComponent<ItemController2> ().getHeldItem ();

			if (playerItem && playerItem.GetComponent<ItemBase>().itemType == ItemBase.ItemType.Scroll) {
				state = DoorState.Opening;
			}

		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			state = DoorState.Closing;
		}
	}



	// Use this for initialization
	void Start () {
		rotationPoint = doorsObject.transform.position + new Vector3 (0, 0, doorsObject.GetComponent<Renderer> ().bounds.size.z / 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (state == DoorState.Opening) {
			if (currentAngle < maxAngle) {
				doorsObject.transform.RotateAround (rotationPoint, Vector3.up, angleStep);
				currentAngle += angleStep;
			}
			else {
				state = DoorState.Open;
			}
		} else if (state == DoorState.Closing) {
			if (currentAngle > minAngle) {
				doorsObject.transform.RotateAround (rotationPoint, Vector3.up, -angleStep);
				currentAngle -= angleStep;
			} else
				state = DoorState.Close;
		}
	}

	public enum DoorState{Close, Open, Closing, Opening};

	private Vector3 rotationPoint;
	private DoorState state = DoorState.Close;
	public GameObject doorsObject = null;
	public float angleStep = 2.0F;
	private float currentAngle = 0.0F;
	private float maxAngle = 90.0F;
	private float minAngle = 0.0F;
}
