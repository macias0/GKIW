using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	public float rotationSpeed = 100.0F;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 euler = transform.localRotation.eulerAngles;
		if (Input.GetKey (KeyCode.Z)) //head down
		{
			if( euler.x < 30.0F || ( euler.x >= 298.0F  )  )
				euler.x += rotationSpeed * Time.deltaTime;
			if(euler.x > 30.0F && euler.x < 90.0F)
				euler.x = 30.0F;
		}
		if (Input.GetKey (KeyCode.X)) //head up
		{
			if (euler.x > 300.0F || euler.x <= 32.0F) 
			{
				Debug.Log ("glowa w gore");
				euler.x -= rotationSpeed * Time.deltaTime;
			}
			if (euler.x < 300.0F && euler.x > 180)
				euler.x = 300.0F;
		}

		if (Input.GetKey (KeyCode.Q)) 
		{
			euler.y -= rotationSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.E)) 
		{
			euler.y += rotationSpeed * Time.deltaTime;
		}
		transform.localRotation = Quaternion.Euler (euler);

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
