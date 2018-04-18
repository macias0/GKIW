using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) 
		{
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y += Physics.gravity.y * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}


	public float speed = 10.0F;
	public float jumpSpeed = 6.0F;
}
