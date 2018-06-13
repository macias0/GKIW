using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {


	private Rigidbody rigidbody;
//	private Vector3 moveDirection = Vector2.zero;

	public float speed = 10.0F;
	public float jumpSpeed = 10.0F;
	public float rotationSpeed = 100.0F;

	private float distToGround;

	private bool isGrounded()
	{
//		Physics.Raycast (transform.position, Vector3.down, 10);
		return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
	}


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		Collider collider = GetComponent<Collider> ();
		distToGround = collider.bounds.extents.y;
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
	}


	void FixedUpdate()
	{
		Vector3 moveDirection = Vector3.zero;
		if (isGrounded()) 
		{
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
//
		}
		//moveDirection.y += Physics.gravity.y * Time.deltaTime;
		rigidbody.AddForce (moveDirection, ForceMode.Force);

//		if (Input.GetKey (KeyCode.UpArrow)) 
//		{
//			rigidbody.AddForce(Vector3.forward * speed, ForceMode.Force);
//		}
//
//		if (Input.GetKey (KeyCode.DownArrow)) 
//		{
//			rigidbody.AddForce(Vector3.back * speed, ForceMode.Force);
//		}
//
//		if (Input.GetKey (KeyCode.LeftArrow)) 
//		{
//			rigidbody.AddForce(Vector3.left * speed, ForceMode.Force);
//		}
//
//		if (Input.GetKey (KeyCode.RightArrow)) 
//		{
//			rigidbody.AddForce(Vector3.right * speed, ForceMode.Force);
//		}

	}
}
