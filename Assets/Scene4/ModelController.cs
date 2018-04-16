using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {


	private CharacterController controller;
	private Animator animator;
	private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

//		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Jump"))
//			Debug.Log ("jump anim");

		if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) 
		{
			moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);

			moveDirection *= speed;


			if (Input.GetAxis ("Vertical") > 0) 
			{
				if (Input.GetKey (KeyCode.LeftShift)) {
					Debug.Log ("Odpalam sprint");
					moveDirection *= 2.0F;
					animator.SetFloat ("speed", 4.0F);
				} else {
					//Debug.Log ("Odpalam chodzenie");
					animator.SetFloat ("speed", 2.0F);
				}
			}
			else if(Input.GetAxis ("Vertical") < 0)
				animator.SetFloat ("speed", -2.0F);
			else
				animator.SetFloat ("speed", 0.0F);
			


				
			if (Input.GetButtonDown ("Jump")) {
				animator.SetTrigger ("jump");
				//moveDirection.y = jumpSpeed;
			}
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime, 0);



		}
		//moveDirection.y += Physics.gravity.y * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);


	}


	public float speed = 10.0F;
	public float rotationSpeed = 6.0F;
	public float jumpSpeed = 6.0F;
}
